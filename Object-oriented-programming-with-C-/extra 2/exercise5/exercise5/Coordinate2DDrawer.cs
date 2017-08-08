using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace exercise5
{
    class Coordinate2DDrawer : CoordinateDrawer
    {
        public Coordinate2DDrawer() { }
        public Coordinate2DDrawer(Canvas canvas) : base(canvas) { }
        public Coordinate2DDrawer(Canvas canvas, int minx, int maxx, int miny, int maxy)
            : base(canvas, minx, maxx, miny, maxy)
        {
            stepx = canvas.Width / (maxx - minx); //i 
            stepy = canvas.Height / (maxy - miny); //j 
        }

        public Point Convert(Point p)
        {
            return new Point(p.X / stepx + minx, (canvas.Height - p.Y) / stepy + miny);
        }

        public Point Convert(double x, double y)
        {
            double x0 = ((maxx - minx) - maxx) * stepx;
            double y0 = maxy * stepy;
            return new Point(x0 + x * stepx, y0 - y * stepy);
        }

        public override void DrawPolygon(PointCollection points, SolidColorBrush color)
        {
            PointCollection scaled = new PointCollection();
            foreach (var p in points)
                scaled.Add(Convert(p.X, p.Y));
            base.DrawPolygon(scaled, color);
        }

        /// <summary>
        /// calculates the coordinates of line y = ax + b
        /// </summary>
        /// <param name="a">a</param>
        /// <param name="b">b</param>
        /// <returns>list of points in given line</returns>
        public void DrawLine(double a, double b, SolidColorBrush color, int thickness = 1)
        {
            Point start = new Point();
            Point end = new Point();
            start = Convert(minx, a * minx + b);
            end = Convert(maxx, a * maxx + b);

            //line is drawn based on the first and last points in the list 
            DrawLine(start.X, start.Y, end.X, end.Y, color, thickness);
        }

        public void DrawDataPoint(Point p, SolidColorBrush color, Markers mark)
        {
            double length = 0.3;
            Point start = new Point();
            Point end = new Point();
            int thickness = 2;

            switch (mark)
            {
                case Markers.CROSS:
                    {
                        start = Convert(p.X - length, p.Y);
                        end = Convert(p.X + length, p.Y);
                        DrawLine(start.X, start.Y, end.X, end.Y, color, thickness);

                        start = Convert(p.X, p.Y - length);
                        end = Convert(p.X, p.Y + length);
                        DrawLine(start.X, start.Y, end.X, end.Y, color, thickness);
                        break;
                    }
                case Markers.CIRCLE:
                    {
                        Point center = Convert(p.X, p.Y);
                        DrawCircle(length, center.X, center.Y, color, thickness);
                        break;
                    }
                case Markers.DIAMOND:
                    {
                        PointCollection points = new PointCollection();
                        points.Add(Convert(p.X - length, p.Y));
                        points.Add(Convert(p.X, p.Y - length));
                        points.Add(Convert(p.X + length, p.Y));
                        points.Add(Convert(p.X, p.Y + length));
                        base.DrawPolygon(points, color);
                        break;
                    }
                default:
                    {
                        PointCollection points = new PointCollection();
                        points.Add(Convert(p.X - length, p.Y));
                        points.Add(Convert(p.X + length, p.Y));
                        points.Add(Convert(p.X, p.Y - length));

                        points.Add(Convert(p.X, p.Y + length));
                        base.DrawPolygon(points, color);
                        break;
                    }
            }
        }

    }
}

