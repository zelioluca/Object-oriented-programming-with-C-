using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace exercise_6
{
    class Drawer
    {
         //canvas drawing pad
        protected Canvas canvas;
        protected double stepy;
        protected double stepx;
        protected double startx;
        protected double starty;
        protected int directionx;
        protected int directiony;
        protected Random random = new Random();
        private SolidColorBrush color;
        private SolidColorBrush color1 = Brushes.Blue;
        private SolidColorBrush color2 = Brushes.YellowGreen;
        //maze elements in canvas
        private Maze maze = new Maze();
        protected Ellipse ball;
        //keyparts e, l, r
        protected Ellipse e;
        protected Line l;
        protected Rectangle r;
        protected Point keyPoint;
        //door
        protected Rectangle door;
        protected Point doorPoint;
        //maze
        protected List<Line> bars = new List<Line>();
        public bool next { get; set; }
        public Drawer()
        {
        }

        /// <summary>
        /// canvas given as a parameter should not resize after this
        /// </summary>
        public Drawer(Canvas canvas)
        {
            this.canvas = canvas;
            stepy = canvas.Height / 60;
            stepx = canvas.Width / 60;         
        }

        /// <summary>
        /// initializes canvas, starting position for the ball, initial direction and next level
        /// </summary>
        public bool Init()
        {
            bool result = false;
            canvas.Children.Clear();
            color = color1;
            startx = random.Next((int)(canvas.Width / 10), (int)(canvas.Width - canvas.Width / 10));
            starty = random.Next((int)(canvas.Width / 10), (int)(canvas.Height - canvas.Width / 10));
            directionx = (random.Next(10000) % 2 == 0) ? 1 : -1;
            directiony = (random.Next(10000) % 3 == 0) ? 1 : -1;
            if (maze.Next(next).Equals(LEVELS.EASY))
            {
                MessageBox.Show("EASY");
                DrawMaze();
                result = true;
            }
            else if (maze.level.Equals(LEVELS.INTERMEDIATE))
            {
                MessageBox.Show("INTERMEDIATE");
                DrawMaze();
                result = true;
            }
            else if (maze.level.Equals(LEVELS.DIFFICULT))
            {
                MessageBox.Show("DIFFICULT");
                DrawMaze();
                result = true;
            }
            else if (maze.level.Equals(LEVELS.EXPERT))
            {
                MessageBox.Show("EXPERT");
                DrawMaze();
                result = true;
            }
            else if (maze.Next(next).Equals(LEVELS.OVER))
            {
                DrawText(canvas.Width / 2 - 50, canvas.Height / 2, "GAME OVER");
            }
            return result;
        }
        /// <summary>
        /// draws the original maze (bars and Key)
        /// </summary>
        public void DrawMaze()
        {
            DrawBar(maze.Bars(), Brushes.Coral, maze.Division);
            drawKey(maze.Key(), maze.Division);
        }


        /// <summary>
        /// draws ball, checks if it hits Key, if Key is hit Door is drawn and ball color changed
        /// if Door is hit returns true
        /// </summary>
        public bool Draw()
        {
            bool result = false;
            //canvas bounds
            //vertical
            if (startx <= (canvas.Width / maze.Division) / 3 || startx >= canvas.Width - (canvas.Width / maze.Division) / 3)
                directionx *= -1;
            //horizontal
            if (starty <= (canvas.Height / maze.Division) / 3 || starty >= canvas.Height - (canvas.Height / maze.Division) / 3)
                directiony *= -1;
            //maze bars
            int hit = BarHit(new Point(startx, starty), (canvas.Width / maze.Division) / 3, (canvas.Height / maze.Division) / 3);
            //horizontal
            if (hit == -1)
                directiony *= -1;
            //vertical
            if (hit == 1)
                directionx *= -1;
            //key picked
            if (color != color2 &&
                KeyHit(new Point(startx, starty), (canvas.Width / maze.Division) / 3, (canvas.Height / maze.Division) / 3))
            {
                //change ball color
                color = color2;
                //door visible
                drawDoor(maze.Door(), maze.Division);
            }
            //draw ball
            DrawBall((canvas.Width / maze.Division) / 2, startx += stepx * directionx, starty += stepy * directiony, color);
            if (color == color2)
            {
                if (DoorHit(new Point(startx, starty), (canvas.Width / maze.Division) / 3, (canvas.Height / maze.Division) / 3))
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// changes direction if user presses arrow keys
        /// </summary>
        /// <param name="key">pressed key</param>
        public void ChangeDirection(Key key)
        {
            if (key == Key.Left)
                directionx = -1;
            //other keys
            if (key == Key.Right)
                directionx = 1;
            if (key == Key.Up)
                directiony = -1;
            if (key == Key.Down)
                directiony = 1;


        }

 

        /// <summary>
        /// clears previous circle and
        /// draws circle and places it into the given position in canvas
        /// <param name="korkeus">diameter</param>
        /// <param name="positiox">center of the circle x coordinate</param>
        /// <param name="positioy">centre of the circle y coordinate</param>
        /// </summary>
        protected void DrawBall(double diameter, double centerx, double centery, SolidColorBrush color)
        {
            canvas.Children.Remove(ball);
            ball = new Ellipse();
            ball.Height = diameter;
            ball.Width = diameter;
            ball.Fill = color;

            Canvas.SetLeft(ball, centerx - ball.Width / 2.0);
            Canvas.SetTop(ball, centery - ball.Height / 2.0);

            canvas.Children.Add(ball);
        }

        /// <summary>
        /// draws maze bars (lines) that are relative points and adds them into 
        /// bars list with real coordinates
        /// </summary>
        /// <param name="points">Maze bars represented with relative pairs of points</param>
        /// <param name="color"></param>
        /// <param name="division"></param>
        protected void DrawBar(List<Maze.Pair> points, SolidColorBrush color, int division)
        {
            bars.Clear();
            foreach (var v in points)
            {
                Line line = new Line()
                {
                    X1 = v.start.X * canvas.Width / division,
                    Y1 = v.start.Y * canvas.Height / division,
                    X2 = v.end.X * canvas.Width / division,
                    Y2 = v.end.Y * canvas.Height / division
                };
                line.StrokeThickness = 4;
                line.Stroke = color;
                canvas.Children.Add(line);
                bars.Add(line);
            }
        }

        /// <summary>
        /// draws key (ellipse, line and rectangle) centered around given point
        /// </summary>
        protected void drawKey(Point p, int division)
        {
            keyPoint = new Point(p.X * canvas.Width / division, p.Y * canvas.Height / division);
            SolidColorBrush color = Brushes.Gold;
            int size = 5;
            e = new Ellipse();
            e.Height = size;
            e.Width = 2*size;
            e.Stroke = color;
            Canvas.SetLeft(e, keyPoint.X - e.Width / 2.0);
            Canvas.SetTop(e, (keyPoint.Y - size) - e.Height / 2.0);
            canvas.Children.Add(e);
            l = new Line() { X1 = keyPoint.X, X2 = keyPoint.X, Y1 = keyPoint.Y - size, Y2 = keyPoint.Y + size };
            l.Stroke = color;
            canvas.Children.Add(l);
            r = new Rectangle();
            r.Fill = color;
            r.Width = 2 * size; 
            r.Height = size;
            Canvas.SetLeft(r, keyPoint.X - r.Width);
            Canvas.SetTop(r, keyPoint.Y + size);
            canvas.Children.Add(r);
        }
       
        /// <summary>
        /// draws door (rectangle) with upper right corner in given point
        /// </summary>
        protected void drawDoor(Point p, int division)
        {
            //remove key
            canvas.Children.Remove(e);
            canvas.Children.Remove(l);
            canvas.Children.Remove(r);
            doorPoint = new Point(p.X * canvas.Width / division, p.Y * canvas.Height / division);
            int size = (int)canvas.Width / division;
            door = new Rectangle();
            door.Fill = Brushes.Fuchsia;
            door.Width = size / 2;
            door.Height = size;
            Canvas.SetLeft(door, doorPoint.X);
            Canvas.SetTop(door, doorPoint.Y );
            canvas.Children.Add(door);
        }

        /// <summary>
        /// draws text (the mark of game over) to starting point given as a parameter
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="text"></param>
        protected void DrawText(double x, double y, string text)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.Foreground = color;
            textBlock.FontSize = 20;
            textBlock.FontWeight = FontWeights.ExtraBold; 
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            canvas.Children.Add(textBlock);
        }

        /// <summary>
        /// checks if the point is within given distance of bars
        /// </summary>
        /// <param name="p">point</param>
        /// <param name="distancex">horizontal level distance</param>
        /// <param name="distancey">vertical level distance</param>
        /// <returns>-1 if horizontal ba was hit +1 if vertical, 0 if no hit</returns>
        protected int BarHit(Point p, double distancex, double distancey)
        {
            int dir = 0; //-1 horizontal hit, +1 vertical hit, 0 no hit
            foreach (var v in bars)
            {
                //vertical
                if (v.X1 == v.X2) 
                {
                    if (Math.Abs(p.X - v.X1) <= distancex && p.Y >= v.Y1 && p.Y <= v.Y2)
                        dir = 1;
                }
                //horizontal
                if (v.Y1 == v.Y2)
                {
                    if (Math.Abs(p.Y - v.Y1) <= distancey && p.X >= v.X1 && p.X <= v.X2)
                        dir = -1;
                }

            }
            return dir;
        }

        /// <summary>
        /// checks if the point is within given distance of Key
        /// </summary>
        /// <returns>true = hit, false = miss</returns>
        protected bool KeyHit(Point p, double distancex, double distancey)
        {
            bool result = false;
            if (Math.Abs(p.X - keyPoint.X) <= distancex && Math.Abs(p.Y - keyPoint.Y) <= distancey)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// checks if the point is within given distance of Door
        /// </summary>
        /// <returns>true = hit, false = miss</returns>
        protected bool DoorHit(Point p, double distancex, double distancey)
        {
            bool result = false;
            //check if the ball center point is within given distance of doorPoint
            if (Math.Abs(p.X - doorPoint.X) <= distancex && Math.Abs(p.Y - doorPoint.Y) <= distancey*2)
            {
                result = true;
            }

            return result;
        }

    }
}


