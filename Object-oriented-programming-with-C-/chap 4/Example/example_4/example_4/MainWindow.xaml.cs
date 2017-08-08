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

namespace example_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TitleGenerator tg;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                tg = new TitleGenerator();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Program will be closed");
                Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string name = input.Text.Trim().ToLower();
            output.Text = tg.Generate(name);
        }
    }
}
