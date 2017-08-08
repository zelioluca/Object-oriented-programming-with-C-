using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace example_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<DataItem> data;
        public ObservableCollection<DataItem> Data { get { return data; } set { data = value; } }
        Coordinate2DDrawer drawer;
        private int min = -20;
        private int max = 20;

        public MainWindow()
        {
            InitializeComponent();  
            DataContext = this;
            drawer = new Coordinate2DDrawer(canvas, 0, 31, min, max);
            drawer.DrawAxis();
            InitializeDatagrid();           
        }

        private void InitializeDatagrid()
        {
            data = new ObservableCollection<DataItem>();
            dataGrid1.ItemsSource = Data;            
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            Draw();

            //if you want to verify which cell you selected and changed
            //if (dataGrid1.SelectedItem != null)
            //{
            //    object o = dataGrid1.CurrentItem;
            //    if (o is DataItem)
            //    {
            //        MessageBox.Show((o as DataItem).ToString());
            //    }
            //}
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(canvas);
            Point pp = drawer.Convert(p);
            point.Text = String.Format("(x, y) = ({0:N0}, {1:#0.0})", pp.X, pp.Y);
        }

        private void canvas_MouseLeave(object sender, MouseEventArgs e)
        {
            point.Text = "";
        }
        
        private void new_Click(object sender, RoutedEventArgs e)
        {
            drawer.Clear();
            data.Clear();
        }

        private void read_Click(object sender, RoutedEventArgs e)
        {
            data.Clear();
            Data = ReadData();
            dataGrid1.ItemsSource = Data;
            Draw();
        }

        private void Draw()
        {
            drawer.Clear();
            Markers mark;
            SolidColorBrush color;
            foreach (var v in data)
            {
                switch (v.Meter)
                {
                    case METERS.NAMES.RUISSALO:
                        mark = Markers.CIRCLE; color = Brushes.Blue; break;
                    case METERS.NAMES.CENTER:
                        mark = Markers.CROSS; color = Brushes.Red; break;
                    case METERS.NAMES.AIRPORT:
                        mark = Markers.DIAMOND; color = Brushes.Green; break;
                    default:
                        mark = Markers.OTHER; color = Brushes.Orange; break;
                }
                drawer.DrawDataPoint(new Point(v.X, v.Y), color, mark);
            }
        }
         
        /// <summary>
        /// Generates randomly some test data.
        /// </summary>
        /// <returns>test data</returns>
        public ObservableCollection<DataItem> ReadData()
        {
            ObservableCollection<DataItem> d = new ObservableCollection<DataItem>();
            Random r = new Random();
            for (uint i = 0; i < 30; i++)
            {
                int place = r.Next(min, max);
                d.Add(new DataItem(i, r.NextDouble() * place,
                place % 3 == 0 ? METERS.NAMES.AIRPORT : (place % 3 == 1 ? METERS.NAMES.CENTER : METERS.NAMES.RUISSALO)));
            }
            return d;
        }


    }
}
