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
using pelitkirijasto;

namespace BoardGame
{
    /// <summary>
    /// Interaction logic for MineBoard.xaml
    /// </summary>
    public partial class MineBoard : UserControl
    {
        private MiniMine game; 
        public MineBoard()
        {
            InitializeComponent();
            game = new MiniMine(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            game.Play(sender); 
        }
        public void Init()
        { }
    }
}
