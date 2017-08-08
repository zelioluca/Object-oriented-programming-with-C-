using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace tetrisMazeVer2._0
{
    [Serializable]
    public class Game
    {
       [NonSerialized] protected Canvas canvas;
       [NonSerialized] protected Canvas a1;
       [NonSerialized] protected Canvas a2;
       [NonSerialized] protected Canvas a3;
       [NonSerialized] protected Canvas b1;
       [NonSerialized] protected Canvas b2;
       [NonSerialized] protected Canvas b3;
       [NonSerialized] protected Canvas c1;
       [NonSerialized]protected Canvas c2;
       [NonSerialized] protected Canvas c3;
        private string file = "serialize.dat";   
        
        protected Random random = new Random();
        public string[] check = new string[9];

        [NonSerialized] private SolidColorBrush color;
        [NonSerialized] private SolidColorBrush Blue = Brushes.Blue;
        [NonSerialized] private SolidColorBrush Red = Brushes.Red;
        [NonSerialized] protected Ellipse ball;

        protected double stepy;
        protected double stepx;
        protected double starty;
        protected double startx;
        protected int directionx;
        protected int directiony;

        [NonSerialized] protected Rectangle door;
        [NonSerialized] protected Point doorPoint;
        [NonSerialized] protected Point doorPoint1;
        [NonSerialized] protected Point doorPoint2;
        [NonSerialized] protected Point doorPoint3;

        public bool next { get; set; }
        

        private const int division = 6;
        
        public Game(Canvas canvas, Canvas a1, Canvas a2, Canvas a3, Canvas b1, Canvas b2, Canvas b3, Canvas c1, Canvas c2, Canvas c3)
        {
            this.canvas = canvas;
            this.a1 = a1;
            this.a2 = a2;
            this.a3 = a3;
            this.b1 = b1;
            this.b2 = b2;
            this.b3 = b3;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;

            InitArray();
            
            stepx = canvas.Width  / 60;
            stepy = canvas.Height / 60;

            if (File.Exists(file) && MessageBox.Show("Do you want to continue the game?", "continuing", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                State(true);

        }
       

      

        public bool Init()
        {
          
            BallColor();
            bool result = false; 
            canvas.Children.Clear();
            startx = random.Next((int)(canvas.Width / 10), (int)(canvas.Width - canvas.Width / 10));
            starty = 0;
            directionx = (random.Next(100000) % 3 == 0) ? 1 : -1;
            directiony = 1;
            doorPoint1 = drawDoor(new Point(0, 5.5), division, 1);
            doorPoint2 = drawDoor(new Point(2, 5.5), division, 2);
            doorPoint3 = drawDoor(new Point(4, 5.5), division, 3);
            if (BallColor().Equals(1))
            {
                color = Red;
                result = true;
            }
            else 
            {
                color = Blue; 
                result = true;
            }
            return result; 
        }

        public int BallColor()
        {
            int[] arrBall = new int[9];
            int result = 0; 
            int number = random.Next(0, 1000);

            for(int i =0; i< arrBall.Length; i++)
            {
                arrBall[i] = number; 
            }
            for(int i=0; i< arrBall.Length; i++)
            {
                if(arrBall[i] % 2 == 0)
                {
                    result = 1;
                }
                else
                {
                    result = 2; 
                }
            }
            return result; 
        }
        protected void DrawBall (double diameter, double centerX, double centerY, SolidColorBrush color)
        {
            canvas.Children.Remove(ball);
            diameter = 50;
            ball = new Ellipse(); 
            ball.Height = diameter;
            ball.Width = diameter;
            ball.Fill = color;
            //ball.Fill = Red; 
            Canvas.SetLeft(ball, centerX - ball.Width / 2.0);
            Canvas.SetTop(ball, centerY -  ball.Height / 2.0);
            

            canvas.Children.Add(ball); 
        }
        public bool Draw()
        {
            bool result = false;

            if (startx <= (canvas.Width / division) / 3 || startx >= canvas.Width - (canvas.Width / division) / 3)
                directionx *= -1;
            if (starty >= canvas.Height - (canvas.Height / division) / 3)
                directiony *= -1;

            DrawBall((canvas.Width / division) / 2, startx += stepx * directionx, starty += stepy * directiony, color);
            if (DoorHit(new Point(startx, starty), (canvas.Width / division) / 3, (canvas.Height / division) / 3))
            {
                Init();
                //result = true;
            }


            return result; 
        }
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
        protected Point drawDoor(Point p, int division, int color)
        {
            doorPoint = new Point(p.X * canvas.Width / division, p.Y * canvas.Height / division);
            int size = (int)canvas.Width / 3;
            door = new Rectangle();
            switch (color)
            {
                case 1:
                    door.Fill = Brushes.White;
                    break;
                case 2:
                    door.Fill = Brushes.White;
                    break;
                case 3:
                    door.Fill = Brushes.White;
                    break;
                default:
                    door.Fill = Brushes.Black;
                    break;
            }
            door.Width = size;
            door.Height = size / 3;
            Canvas.SetLeft(door, doorPoint.X);
            Canvas.SetTop(door, doorPoint.Y);
            canvas.Children.Add(door);
            return doorPoint;
        }
        protected bool DoorHit(Point p, double distancex, double distancey)
        {
            bool result = false;
            //check if the ball center point is within given distance of doorPoint
            if (Math.Abs(p.X - (doorPoint1.X)) <= distancex * 4 && Math.Abs(p.Y - doorPoint1.Y) <= distancey)
            {
                //MessageBox.Show("1st");
                
                if(check[6] == "" && color == Blue)
                {
                    check[6] = "X";
                    //c1.Background = color;
                    BallInside(color);
                    c1.Children.Add(ball);
                    State(false);
                    Check();

                }
                else if(check[6]== "" && color == Red)
                {
                    check[6] = "O";
                    BallInside(color);
                    c1.Children.Add(ball);
                    State(false);
                    Check();
                }
                else if(check[3] == "" && color == Blue)
                {
                    check[3] = "X";
                    BallInside(color);
                    b1.Children.Add(ball);
                    State(false);
                    Check();
                }
                else if (check[3] == "" && color == Red)
                {
                    check[3] = "O";
                    BallInside(color);
                    b1.Children.Add(ball);
                    State(false); 
                    Check();
                }
                else if(check[0] == "" && color == Blue)
                {
                    check[0] = "X";
                    BallInside(color);
                    a1.Children.Add(ball);
                    State(false);
                    Check();
                }
                else if(check[0] == "" && color == Red)
                {
                    check[0] = "O";
                    BallInside(color);
                    a1.Children.Add(ball);
                    State(false);
                    Check();  
                }
                
                 
                result = true;
            }
            if (Math.Abs(p.X - (doorPoint2.X * 1.5)) <= distancex * 3 && Math.Abs(p.Y - doorPoint2.Y) <= distancey)
            {
                //MessageBox.Show("2nd");

                if (check[7] == "" && color == Blue)
                {
                    check[7] = "X";
                    BallInside(color);
                    c2.Children.Add(ball);
                    State(false);
                    Check();

                }
                else if (check[7] == "" && color == Red)
                {
                    check[7] = "O";
                    BallInside(color);
                    c2.Children.Add(ball);
                    State(false);
                    Check();
                }
                else if (check[4] == "" && color == Blue)
                {
                    check[4] = "X";
                    BallInside(color);
                    b2.Children.Add(ball);
                    State(false);
                    Check();
                }
                else if (check[4] == "" && color == Red)
                {
                    check[4] = "O";
                    BallInside(color);
                    b2.Children.Add(ball);
                    State(false);
                    Check();
                }
                else if (check[1] == "" && color == Blue)
                {
                    check[1] = "X";
                    BallInside(color);
                    a2.Children.Add(ball);
                    State(false);
                    Check();
                }
                else if (check[1] == "" && color == Red)
                {
                    check[1] = "O";
                    BallInside(color);
                    a2.Children.Add(ball);
                    State(false);
                    Check();
                }

                result = true;
            }
            if (Math.Abs(p.X - (doorPoint3.X) * 1.2) <= distancex * 3 && Math.Abs(p.Y - doorPoint3.Y) <= distancey)
            {
               // MessageBox.Show("3rd");

                if (check[8] == "" && color == Blue)
                {
                    check[8] = "X";
                    BallInside(color);
                    c3.Children.Add(ball);
                    State(false);
                    Check();

                }
                else if (check[8] == "" && color == Red)
                {
                    check[8] = "O";
                    BallInside(color);
                    c3.Children.Add(ball);
                    State(false);
                    Check();
                }
                else if (check[5] == "" && color == Blue)
                {
                    check[5] = "X";
                    BallInside(color);
                    b3.Children.Add(ball);
                    State(false);
                    Check();
                }
                else if (check[5] == "" && color == Red)
                {
                    check[5] = "O";
                    BallInside(color);
                    b3.Children.Add(ball);
                    State(false);
                    Check();
                }
                else if (check[2] == "" && color == Blue)
                {
                    check[2] = "X";
                    BallInside(color);
                    a3.Children.Add(ball);
                    State(false);
                    Check();
                }
                else if (check[2] == "" && color == Red)
                {
                    check[2] = "O";
                    BallInside(color);
                    a3.Children.Add(ball);
                    State(false);
                    Check();
                }

                result = true;
            }

            return result;
        }
        public void BallInside(SolidColorBrush color)
        {
            ball = new Ellipse();
            ball.Height = 50;
            ball.Width = 50;
            ball.Fill = color;
            //ball.Fill = Red; 
            Canvas.SetLeft(ball, 50);
            Canvas.SetTop(ball, 10);
        }
        public void InitArray()
        {
            for(int i =0; i<9; i++)
            {
                check[i] = "";
            }
        }
        private string Check()
        {
            string Winner = "";

            for(int i=0; i< 9; i++)
            {
                if ((i == 0) || (i == 3) || (i == 6))
                    if (((check[i].ToString() == check[i + 1].ToString()) &&
                    (check[i].ToString() == check[i + 2].ToString()) &&
                    (check[i].ToString() != "")))
                    {
                        Winner = check[i].ToString();

                    }
                    else if (((check[i].ToString() == check[(i + 3) % 9].ToString()) &&
                      (check[i].ToString() == check[(i + 6) % 9].ToString()) &&
                      (check[i].ToString() != "")))
                    {
                        Winner = check[i].ToString();
                    }
                    else if (((check[i].ToString() == check[(i + 4) % 9].ToString()) &&
                         (check[i].ToString() == check[(i + 8) % 9].ToString()) &&
                         (check[i].ToString() != "")))
                    {
                        Winner = check[i].ToString();
                    }
                    else if (((check[i].ToString() == check[(i + 5) % 9].ToString()) &&
                         (check[i].ToString() == check[(i + 7) % 9].ToString()) &&
                         (check[i].ToString() != "")))
                    {
                        Winner = check[i].ToString();
                    }
                if ((i == 1) || (i == 2))
                    if (((check[i].ToString() == check[i + 1].ToString()) &&
                    (check[i].ToString() == check[i + 2].ToString()) &&
                    (check[i].ToString() != "")))
                    {
                        Winner = check[i].ToString();
                    }
                    else if (((check[i].ToString() == check[(i + 3) % 9].
                        ToString()) &&
                      (check[i].ToString() == check[(i + 6) % 9].ToString()) &&
                      (check[i].ToString() != "")))
                    {
                        Winner = check[i].ToString();
                    }
                    else if (((check[i].ToString() == check[(i + 4) % 9].ToString()) &&
                         (check[i].ToString() == check[(i + 8) % 9].ToString()) &&
                         (check[i].ToString() != "")))
                    {
                        Winner = check[i].ToString();
                    }
                    else if (((check[i].ToString() == check[(i + 5) % 9].ToString()) &&
                         (check[i].ToString() == check[(i + 7) % 9].ToString()) &&
                         (check[i].ToString() != "")))
                    {
                        Winner = check[i].ToString();
                    }
                if ((i == 4))
                    if (((check[i].ToString() == check[i + 1].ToString()) &&
                    (check[i].ToString() == check[i + 3].ToString()) &&
                    (check[i].ToString() != "")))
                    {
                        Winner = check[i].ToString();
                    }
                    else if (((check[i].ToString() == check[(i + 3) % 9].ToString()) &&
                      (check[i].ToString() == check[(i + 6) % 9].ToString()) &&
                      (check[i].ToString() != "")))
                    {
                        Winner = check[i].ToString();
                    }
                    else if (((check[i].ToString() == check[(i + 4) % 9].ToString()) &&
                         (check[i].ToString() == check[(i + 8) % 9].ToString()) &&
                         (check[i].ToString() != "")))
                    {
                        Winner = check[i].ToString();
                    }
                    else if (((check[i].ToString() == check[(i + 5) % 9].ToString()) &&
                         (check[i].ToString() == check[(i + 7) % 9].ToString()) &&
                         (check[i].ToString() != "")))
                    {
                        Winner = check[i].ToString();
                    }

            }
            DrawText(100, 100, Winner);
            return Winner;
            

        }
        protected void DrawText(double x, double y, string text)
        {
            if (text != "")
            {
                if(text == "X")
                {
                    text = " Blue" + " ";
                }
                else
                {
                    text = "Red" + " "; 
                }
                TextBlock textBlock = new TextBlock();
                textBlock.Text = text + "win";
                textBlock.Foreground = color;
                textBlock.FontSize = 20;
                textBlock.FontWeight = FontWeights.ExtraBold;
                Canvas.SetLeft(textBlock, x);
                Canvas.SetTop(textBlock, y);
                canvas.Children.Add(textBlock);
                MessageBox.Show(text + "win");
                File.Delete(file); 
                Application.Current.Shutdown();
            }
        }
        public void State(bool deserialize)
        {
            if(deserialize)
            {
                FileStream fin;
                BinaryFormatter bf = new BinaryFormatter();
                fin = File.Open(file, FileMode.Open, FileAccess.Read);
                Game game = (Game)bf.Deserialize(fin);
                fin.Close();

                Init();
                for(int i=0; i<9; i++)
                {
                    check[i] = game.check[i];

                    
                }
                if(check[6] == "X")
                {
                    BallInside(Blue);
                    c1.Children.Add(ball);
                }
                if(check[6] == "O")
                {
                    BallInside(Red);
                    c1.Children.Add(ball);
                }
                if(check[3] == "X")
                {
                    BallInside(Blue);
                    b1.Children.Add(ball);
                }
                if(check[3] == "O")
                {
                    BallInside(Red);
                    b1.Children.Add(ball); 
                }
                if(check[0] == "X")
                {
                    BallInside(Blue);
                    a1.Children.Add(ball);
                }
                if(check[0] == "O")
                {
                    BallInside(Red);
                    a1.Children.Add(ball);
                }
                if(check[7] == "X")
                {
                    BallInside(Blue);
                    c2.Children.Add(ball);
                }
                if(check[7] == "O")
                {
                    BallInside(Red);
                    c2.Children.Add(ball);
                }
                if(check[4] == "X")
                {
                    BallInside(Blue);
                    b2.Children.Add(ball);
                }
                if(check[4] == "O")
                {
                    BallInside(Red);
                    b2.Children.Add(ball); 
                }
                if(check[1] == "X")
                {
                    BallInside(Blue);
                    a2.Children.Add(ball); 
                }
                if(check[1] == "O")
                {
                    BallInside(Red);
                    a2.Children.Add(ball); 
                }
                if(check[8] == "X")
                {
                    BallInside(Blue);
                    c3.Children.Add(ball);
                }
                if(check[8] == "O")
                {
                    BallInside(Red);
                    c3.Children.Add(ball);
                }
                if(check[5] == "X")
                {
                    BallInside(Blue);
                    b3.Children.Add(ball); 
                }
                if(check[5] == "O")
                {
                    BallInside(Red);
                    b3.Children.Add(ball);
                }
                if(check[2] == "X")
                {
                    BallInside(Blue);
                    a3.Children.Add(ball);
                }
                if(check[2] == "O")
                {
                    BallInside(Red);
                    a3.Children.Add(ball); 
                }


            }
            else
            {
                FileStream fout;
                BinaryFormatter bf;
                bf = new BinaryFormatter();
                fout = File.Open(file, FileMode.OpenOrCreate, FileAccess.Write);
                Game game = this;
                bf.Serialize(fout, game);
                fout.Flush();
                fout.Close(); 
            }
        }


    }
}
