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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Button[] slots = new Button[9];
        private int moves;

        public MainWindow()
        {
            InitializeComponent();
            this.grid.Children.CopyTo(slots, 0);
            Initialize();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = "";
            Move(sender);

            if (AnnounceSituation(Check(), ref message))
            {
                NewGame(message);
            }
            else
            {
                MachineMove();
            }

            if (AnnounceSituation(Check(), ref message))
            {
                NewGame(message);
            }
        }
    
        private void NewGame(string message)
        {
            if (MessageBox.Show("Do you want to start a new game", message, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Initialize();
            }
            else
            {
                this.Close();
            }
        }
        private void MachineMove()
        {
            int place;

            while (true)
            {
                place = new Random().Next(9);
                if (slots[place].IsEnabled)
                {
                    slots[place].Content = "O";
                    slots[place].IsEnabled = false;
                    moves++;
                    break;
                }
            }
        }
        private void Move(object sender)
        {
            //one possible way to find out the index of the button
            Button b = (Button)sender;
            int place = 0;
            while (true)
            {
                if (slots[place] == b)
                
                    break;
                    place++;
            }
                b.Content = "X";
                //prevent the other marks
                slots[place].IsEnabled = false;
                moves++;
            
        }
        private string Check()
        {
            string Winner = "";

            for (int i = 0; i < 9; i++)
            {
                if ((i == 0) || (i == 3) || (i == 6))
                    if (((slots[i].Content.ToString() == slots[i + 1].Content.ToString()) &&
                    (slots[i].Content.ToString() == slots[i + 2].Content.ToString()) &&
                    (slots[i].Content.ToString() != "")))
                    {
                        Winner = slots[i].Content.ToString();
                    }
                    else if (((slots[i].Content.ToString() == slots[(i + 3) % 9].Content.ToString()) &&
                      (slots[i].Content.ToString() == slots[(i + 6) % 9].Content.ToString()) &&
                      (slots[i].Content.ToString() != "")))
                    {
                        Winner = slots[i].Content.ToString();
                    }
                    else if (((slots[i].Content.ToString() == slots[(i + 4) % 9].Content.ToString()) &&
                         (slots[i].Content.ToString() == slots[(i + 8) % 9].Content.ToString()) &&
                         (slots[i].Content.ToString() != "")))
                    {
                        Winner = slots[i].Content.ToString();
                    }
                    else if (((slots[i].Content.ToString() == slots[(i + 5) % 9].Content.ToString()) &&
                         (slots[i].Content.ToString() == slots[(i + 7) % 9].Content.ToString()) &&
                         (slots[i].Content.ToString() != "")))
                    {
                        Winner = slots[i].Content.ToString();
                    }
                if ((i == 1) || (i == 2))
                    if (((slots[i].Content.ToString() == slots[i + 1].Content.ToString()) &&
                    (slots[i].Content.ToString() == slots[i + 2].Content.ToString()) &&
                    (slots[i].Content.ToString() != "")))
                    {
                        Winner = slots[i].Content.ToString();
                    }
                    else if (((slots[i].Content.ToString() == slots[(i + 3) % 9].Content.ToString()) &&
                      (slots[i].Content.ToString() == slots[(i + 6) % 9].Content.ToString()) &&
                      (slots[i].Content.ToString() != "")))
                    {
                        Winner = slots[i].Content.ToString();
                    }
                    else if (((slots[i].Content.ToString() == slots[(i + 4) % 9].Content.ToString()) &&
                         (slots[i].Content.ToString() == slots[(i + 8) % 9].Content.ToString()) &&
                         (slots[i].Content.ToString() != "")))
                    {
                        Winner = slots[i].Content.ToString();
                    }
                    else if (((slots[i].Content.ToString() == slots[(i + 5) % 9].Content.ToString()) &&
                         (slots[i].Content.ToString() == slots[(i + 7) % 9].Content.ToString()) &&
                         (slots[i].Content.ToString() != "")))
                    {
                        Winner = slots[i].Content.ToString();
                    }
                if ((i == 4))
                    if (((slots[i].Content.ToString() == slots[i + 1].Content.ToString()) &&
                    (slots[i].Content.ToString() == slots[i + 3].Content.ToString()) &&
                    (slots[i].Content.ToString() != "")))
                    {
                        Winner = slots[i].Content.ToString();
                    }
                    else if (((slots[i].Content.ToString() == slots[(i + 3) % 9].Content.ToString()) &&
                      (slots[i].Content.ToString() == slots[(i + 6) % 9].Content.ToString()) &&
                      (slots[i].Content.ToString() != "")))
                    {
                        Winner = slots[i].Content.ToString();
                    }
                    else if (((slots[i].Content.ToString() == slots[(i + 4) % 9].Content.ToString()) &&
                         (slots[i].Content.ToString() == slots[(i + 8) % 9].Content.ToString()) &&
                         (slots[i].Content.ToString() != "")))
                    {
                        Winner = slots[i].Content.ToString();
                    }
                    else if (((slots[i].Content.ToString() == slots[(i + 5) % 9].Content.ToString()) &&
                         (slots[i].Content.ToString() == slots[(i + 7) % 9].Content.ToString()) &&
                         (slots[i].Content.ToString() != "")))
                    {
                        Winner = slots[i].Content.ToString();
                    }

            }
            return Winner;
        }
        private bool AnnounceSituation(string Winner, ref string message)
        {
            bool end = false;

            if (Winner == "X")
            {
                message = "You won," + Winner;
                end = true;
            }
            else if (Winner == "O")
            {
                message = "You lost and" + Winner + "wins";
                end = true;
            }
            else if (moves == 9)
            {
                message = "It's a tie";
                end = true;
            }
            return end;
        }
        private void Initialize()
        {
            for (int i = 0; i < 9; i++)
            {
                slots[i].Content = "";
                slots[i].IsEnabled = true;
                moves = 0;
            }
        }

    

       
    }
}
        
    
     


