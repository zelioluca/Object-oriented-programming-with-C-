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

namespace pelitkirjasto
{
    /// <summary>
    /// Interaction logic for MineBoard.xaml
    /// </summary>

    
    public partial class MineBoard : UserControl
    {
        private MiniMine game;
        public int row = 6;
        private int slots = 4 * 4;
        public int amountofMines = 10; 



        public MineBoard()
        {
            InitializeComponent();
            game = new MiniMine(this);
             
        }

        
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            game.Play(sender); 
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            game.ShowMine(); 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            game.Init();
            //game.Play(sender); 
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var finestra = Window.GetWindow(this);
            finestra.Close(); 
        }

        //private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        //{
        //    if (game != null)
        //    {
                
        //        RadioButton rb = (RadioButton)sender;
        //        switch (rb.Content.ToString())
        //        {
        //            case "Simple":
        //                slots = 6*6;
        //                amountofMines = 10;
        //                break;
        //            case "Medium":
        //                slots = 12*12;
        //                amountofMines = 20;
        //                break;
        //            case "Difficult":
        //                slots = 18*18;
        //                amountofMines = 30;
        //                break;
        //            case "Luca style":
        //                slots = 50*50;
        //                amountofMines = 100;
        //                break;
        //        }
        //        //game.radio(slots, amountofMines);
        //       // game.Play();
        //    }
        //}
    }
}
