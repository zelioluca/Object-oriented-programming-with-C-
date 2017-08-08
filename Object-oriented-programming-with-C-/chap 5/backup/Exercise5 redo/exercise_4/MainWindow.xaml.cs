using System.Windows;
using System.Windows.Input;
using System; // EventArgs
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Media;

namespace exercise5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CommandHandler cmhandler = new CommandHandler();

        List<Data> list { get; set; }

       
        Coordinate2DDrawer drawer;
        private int min = 20;
        private int max = 20;
        public MainWindow()
        {
            InitializeComponent();
            cmhandler.window = this; //Set the Window Property 
            DataContext = this;
            drawer = new Coordinate2DDrawer(canvas, 0, 31, min, max);
            drawer.DrawAxis();
            
            
        }
        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            //Draw();
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

        //private void Draw()
        //{
        //    drawer.Clear();
        //    Coordinate2DDrawer.Markers mark;
        //    SolidColorBrush color;
        //    foreach (var v in list)
        //    {
        //        switch (v.Meter)
        //        {
        //            case Data.METERS.Italy:
        //                mark = Coordinate2DDrawer.Markers.CIRCLE; color = Brushes.Blue;
        //                break;
        //            case Data.METERS.NAMES.Bulgaria:
        //                mark = Coordinate2DDrawer.Markers.CROSS; color = Brushes.Red;
        //                break;
        //            case Data.METERS.NAMES.Korea:
        //                mark = Coordinate2DDrawer.Markers.DIAMOND; color = Brushes.Green;
        //                break;
        //            default:
        //                mark = Coordinate2DDrawer.Markers.OTHER; color = Brushes.Orange;
        //                break;
        //        }
        //        drawer.DrawDataPoint(new Point(v.X, v.Y), color, mark);
        //    }
        //}

        /****allowing menuitems and buttons to be visible all the time****/
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        /****actual commands to be executed****/
        private void New_CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) //New
        {
            cmhandler.New(); 
        }

        private void Open_CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) //Open
        {
            cmhandler.Open();
        }

        private void Save_CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) //Save
        {
            cmhandler.Save(true);

        }

        private void SaveAs_CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) //SaveAs
        {
            cmhandler.Save(false);

        }

        private void Close_CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) //Close
        {
            cmhandler.Close();
        }

   

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            bool re = false;
            re = cmhandler.Close();
            e.Cancel = re; 
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            cmhandler.New();
            drawer.Clear();
            //data.Clear();   // put the list here 
        }

        private void read_Click(object sender, RoutedEventArgs e)
        {
            cmhandler.Open(); 
            //data.Clear();
            //Data = ReadData();
            //dataGrid1.ItemsSource = Data;
            //Draw();
        }
    }
}
