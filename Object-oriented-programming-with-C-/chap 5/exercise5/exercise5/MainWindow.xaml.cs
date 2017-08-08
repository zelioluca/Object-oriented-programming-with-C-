﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel; 


namespace exercise5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CommandHandler cmhandler = new CommandHandler();
        Data Data = new Data();
        List<List>data {get { return Data.MasterList; } }
        ReadWriteDialog obj = new ReadWriteDialog();


        public List<string[]> textForGrid { get; set; }
        public MainWindow window { get; set; }
        Coordinate2DDrawer drawer;
        private int min = -20;
        private int max = 20;
        public MainWindow()
        {
            InitializeComponent();
            cmhandler.window = this;
            Data.window = this;
            DataContext = this;
           
            drawer = new Coordinate2DDrawer(canvas, 0, 31, min, max);
            drawer.DrawAxis();
            
        }
        
       
       

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
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
           //re = cmhandler.Close();
            e.Cancel = re;
        }


        private void canvas_MouseLeave(object sender, MouseEventArgs e)
        {
            point.Text = "";
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(canvas);
            Point pp = drawer.Convert(p);
            point.Text = String.Format("(x, y) = ({0:N0}, {1:#0.0})", pp.X, pp.Y);
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            drawer.Clear();
            dataGrid1.Columns.Clear();
            
         

        }

        private void read_Click(object sender, RoutedEventArgs e)
        {
            
            Draw();

        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
           
            Draw();

            if (dataGrid1.SelectedItem != null)
            {
                object o = dataGrid1.CurrentItem;
                if (o is List)
                {
                    MessageBox.Show((o as List).ToString());
                }
            }
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
                    case "Lecco":
                        mark = Markers.CIRCLE; color = Brushes.Blue;
                        break;
                    case "helsinki":
                        mark = Markers.CROSS; color = Brushes.Red;
                        break;
                    case "tampere":
                        mark = Markers.DIAMOND; color = Brushes.Green;
                        break;
                    default:
                        mark = Markers.OTHER; color = Brushes.Orange;
                        break;
                }
                drawer.DrawDataPoint(new Point(v.X, v.Y), color, mark);
            }
        }
    }
}
