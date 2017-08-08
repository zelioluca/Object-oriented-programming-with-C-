using System;
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

namespace boardgames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Windows_Closing(object sender, System.ComponentModel.CancelEventArgs e)  //why doesn t work?
        {
            if(MessageBox.Show("Do you really want to exit?", "Board games",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                e.Cancel = true;  
            }
           
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Close(); 
        }
    }
}
