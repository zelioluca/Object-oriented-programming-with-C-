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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for board.xaml
    /// </summary>
    public partial class board : UserControl
    {
       
        private Game game;
        public board()
        {
            InitializeComponent();
            game = new Game();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            game.Play(sender);

            
        }
    }
}
