using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Memory_only
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //amount of places 4x4, 6x6, 8x8, 10X10, 12X12
        private int places = 4; //default size 4*4
        //needed more than once;
        private Board b;

        public MainWindow()
        {
            InitializeComponent();
            b = new Board(board, result, places, rbs);     
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            //called fromn InitializeComponents because by default 4x4 is checked
            RadioButton rb = (RadioButton)sender;
            switch (rb.Content.ToString())
            {
                case "4x4": places = 4; //4X4
                    break;
                case "6x6": places = 6; //6X6
                    break;
                case "8x8": places = 8; //8X8
                    break;
                case "10x10": places = 10; //10X10
                    break;
                case "12x12": places = 12; //12X12
                    break;
                default: places = 4; //4X4
                    break;
            }
            if (b != null) //first time the game does not exist
                b.InitBoard(places);
 
        }
        //show all
        private void ShowButtonClick(object sender, RoutedEventArgs e)
        {
            b.Show();
            result.Text = "Start a new game";

        }
        //start a new game
        private void NewButtonClick(object sender, RoutedEventArgs e)
        {
            b.InitBoard(places);
        }
    }
}
