using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TetrisMaze
{
    public class Game
    {
        private Canvas canvas;
        protected Ellipse ball;
        private SolidColorBrush color;
        private SolidColorBrush blue = Brushes.Blue;
        private SolidColorBrush red = Brushes.Red;
        protected int directionx;
        protected int directiony;
        protected double stepx;
        protected double stepy;
        //protected double centerX;
        //protected double centerY;
        protected double startx;
        protected double starty;
        protected Random rnd = new Random();

        public bool Next { get; set; }

        int[] arrayBall = new int[9]; 
        
        public Game()
        { }

        public Game(Canvas canvas)
        {
            this.canvas = canvas;
            stepx = canvas.Width   / 60;
            stepy = canvas.Height /  60;
            
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

        public void DrawBall(double centerX, double centerY)
        {
            ball = new Ellipse();

            canvas.Children.Remove(ball); 

            int number = rnd.Next(0, 9);
            //centerX = canvas.Width / 2;
            //centerY = canvas.MinHeight;
            double diameter = 50;


            //for (int i = 0; i < 9; i++)
            //{
            //    arrayBall[i] = number;
            //}

            ball.Height = diameter;
            ball.Width = diameter;
            ball.Fill = blue;

            //for (int i = 0; i < arrayBall.Length; i++)
            //{
            //    if (arrayBall[i] % 2 == 0)
            //    {
            //        ball.Fill = blue;
            //    }
            //    else
            //    {
            //        ball.Fill = red;
            //    }
            //}
            Canvas.SetLeft(ball, centerX);
            Canvas.SetTop(ball, 0);
            canvas.Children.Add(ball); 
             
        }
        public bool Draw()
        {
            //startx = canvas.Width / 2;
            //starty = canvas.MinHeight; 
            bool result = false;

            if (startx <= (canvas.Width) / 3 || startx >= (canvas.Width) / 3)
                directionx *= -1;
            
            if (starty <= (canvas.Height) / 3 || starty >= (canvas.Height) / 3)
                directiony *= -1;
           
            DrawBall(startx += stepx * directionx, starty += starty *directiony);
            
            return result; 
        }
        public bool Init()
        {
            canvas.Children.Clear(); 
            bool result = true;
            //canvas.Children.Clear();
            startx = canvas.Width / 2;
            starty = canvas.MinHeight;
            //directionx = (int)canvas.Width / 2;
            //directiony = (int)canvas.MinHeight;
            //startx = rnd.Next((int)(canvas.Width / 10), (int)(canvas.Width - canvas.Width / 10));
            //starty = rnd.Next((int)(canvas.Width / 10), (int)(canvas.Height - canvas.Width / 10));
            directionx = (rnd.Next(10000) % 2 == 0) ? 1 : -1;
            directiony = (rnd.Next(10000) % 3 == 0) ? 1 : -1;

            return result; 
        }
            
        

        
        
    }
}
