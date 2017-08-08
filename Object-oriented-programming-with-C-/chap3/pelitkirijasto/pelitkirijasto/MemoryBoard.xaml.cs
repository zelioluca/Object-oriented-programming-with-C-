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

namespace pelitkirijasto
{
    /// <summary>
    /// Interaction logic for MemoryBoard.xaml
    /// </summary>
    public partial class MemoryBoard : UserControl
    {
        private MemoryGame game;

        private int slots = 4 * 4;
        public MemoryBoard()
        {
            InitializeComponent();
            game = new MemoryGame(this);
            game.NewGame();
        }
        public void Init()
        {
            grid.Children.Clear();
            int i = 0;
            while (i++ < slots)
            {
                Canvas canvas = new Canvas();
                game.Empty(canvas);
                canvas.MouseLeftButtonDown += new MouseButtonEventHandler(b_MouseLeftButtonDown);
                grid.Children.Add(canvas);
            }
        }
        private void b_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (game.Pelaa(sender))
            {
                var myWindows = Window.GetWindow(this);
                myWindows.Close();
            }
        }
        private void Show_Click(object sender, RoutedEventArgs e)
        {
            game.Show();
            result.Text = "Start a new game";
        }
        private void New_Click(object sender, RoutedEventArgs e)
        {
            game.NewGame(slots);
        }
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (game != null)
            {
                RadioButton rb = (RadioButton)sender;
                switch (rb.Content.ToString())
                {
                    case "4x4":
                        slots = 4 * 4;
                        break;
                    case "6x6":
                        slots = 6 * 6;
                        break;
                    case "8x8":
                        slots = 8 * 8;
                        break;
                    case "10x10":
                        slots = 10 * 10;
                        break;
                    default:
                        slots = 4 * 4;
                        break;
                }
                game.NewGame(slots);
            }
        }
    }
}
