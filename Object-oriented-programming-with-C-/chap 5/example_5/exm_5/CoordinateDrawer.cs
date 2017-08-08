using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace example_5
{
    class CoordinateDrawer
    {
        protected Canvas canvas;
        protected const int major = 5;
        protected const int minor = 1;
        protected int minx = -10;
        protected int miny = -10;
        protected int maxx = 10;
        protected int maxy = 10;
        protected int baseElements;
        protected double stepx;
        protected double stepy;

        public CoordinateDrawer()
        {
        }
        public CoordinateDrawer(Canvas canvas)
        {
            this.canvas = canvas;
            this.canvas.Background = Brushes.Wheat;
        }
        public CoordinateDrawer(Canvas canvas, int minx, int maxx, int miny, int maxy)
            : this(canvas)
        {
            this.minx = minx;
            this.miny = miny;
            this.maxx = maxx;
            this.maxy = maxy;
            stepx = canvas.Width / (maxx - minx); //i pituus
            stepy = canvas.Height / (maxy - miny); //j pituus 
        }
        public void DrawText(double x, double y, string text)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.Foreground = System.Windows.Media.Brushes.Black;
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            canvas.Children.Add(textBlock);
        }
        public void Clear()
        {
            while (canvas.Children.Count > baseElements)
            {
                canvas.Children.RemoveAt(canvas.Children.Count - 1);
            }
        }
        public virtual void DrawAxis()
        {
            //x-axis
            DrawLine(0, stepy * maxy, canvas.Width, stepy * maxy);

            //y-axis
            DrawLine(canvas.Width - stepx * maxx, 0, canvas.Width - stepx * maxx, canvas.Height);

            //markers x-axis
            for (int i = 0; i < (maxx - minx); i++)
            {
                double x = stepx * i;
                double y = stepy * maxy;
                if (i % 5 == 0)
                    DrawLine(x, y + 4, x, y - 4);
                else
                    DrawLine(x, y + 2, x, y - 2);
            }
            //markers y-axis
            for (int i = 0; i < (maxy - miny); i++)
            {
                double x = canvas.Width - stepx * maxx;
                double y = stepy * i;
                if (i % 5 == 0)
                    DrawLine(x - 4, y, x + 4, y);
                else
                    DrawLine(x - 2, y, x + 2, y);
            }
            //when clearing lines coordinates remain
            baseElements = canvas.Children.Count;
        }



        public virtual void DrawLine(double startx, double starty, double endx, double endy)
        {
            Line line = new Line() { X1 = startx, Y1 = starty, X2 = endx, Y2 = endy };

            line.StrokeThickness = 1;
            line.Stroke = Brushes.Black;

            canvas.Children.Add(line);
        }

        public virtual void DrawLine(double startx, double starty, double endx, double endy, SolidColorBrush color, int thickness)
        {
            Line line = new Line() { X1 = startx, Y1 = starty, X2 = endx, Y2 = endy };

            line.StrokeThickness = thickness;
            line.Stroke = color;

            canvas.Children.Add(line);
        }

        public virtual void DrawPolygon(PointCollection points, SolidColorBrush color)
        {
            PointCollection scaled = new PointCollection();
            Polygon polygon = new Polygon();
            polygon.Points = points;
            polygon.StrokeThickness = 2;
            polygon.Fill = color;

            canvas.Children.Add(polygon);
        }

        /// <summary>
        /// draws circle and places it into the given position ini canvas
        /// <param name="korkeus">diameter</param>
        /// <param name="positiox">center of the circle x coordinate</param>
        /// <param name="positioy">centre of the circle y coordinate</param>
        /// </summary>
        public void DrawCircle(double diameter, double centerx, double centery, SolidColorBrush color, int thickness)
        {
            //koko oikea paikka väärä
            Ellipse circle = new Ellipse();
            circle.Height = diameter * (stepx * 2);
            circle.Width = diameter * (stepx * 2);

            circle.StrokeThickness = thickness;
            circle.Stroke = color;

            Canvas.SetLeft(circle, centerx - circle.Width / 2.0);
            Canvas.SetTop(circle, centery - circle.Height / 2.0);

            canvas.Children.Add(circle);
        }
    }
}
