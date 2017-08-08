using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace pelitkirjasto
{
    public class TicTacToe: BoardGame
    {   //copy of buttons in the user interface
        //private Button[] slots = new Button[9];
        new protected Button[] places = new Button[9];
        //ammount of moves in one game
        private int moves;

        public TicTacToe(TTTBoard tTTBoard)
        {
            //copy the reference of the buttons in Grid named grid to slots table
            tTTBoard.grid.Children.CopyTo(places, 0);
            Initialize();
        }

        public TicTacToe()
        {
        }

        //<summary>
        //make a move and machine's counter move
        //</summary>
        //<param name ="sender">button where the eventwas raised</param>
       new public void Play(object sender) //was internal attention 
        {
            //message shows user the situation of the game
            string message = "";
            //user move
            Move(sender);

            if (AnnounceSituation(Check(), ref message)) //has the game ended?
            {
                NewGame(message);
            }
            else
            {
                //machine move this point is not reached if the game ended after user's move
                MachineMove();

                if (AnnounceSituation(Check(), ref message)) //has the game ended?
                {
                    NewGame(message);
                }

            }


        }
        public void NewGame(string message)
        {
            //if (MessageBox.Show("Do you want to start a new game?", message, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //{
            //    Initialize();
            //}
            //else
            //{
            //   // Application.Current.Shutdown();
            //if(MessageBox.Show("Do you really want to exit?", "Board Games", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //    {
            //        Application.Current.Shutdown();

            //    }
            //    else
            //    {
            //        Initialize(); 
            //    }

            //}
            MessageBox.Show(message, "Board Game", MessageBoxButton.OK);
            Initialize(); 
        }


        private void MachineMove()
        {
            int place;

            while (true)
            {
                place = new Random().Next(9);
                if (places[place].IsEnabled)
                {
                    places[place].Content = "O";
                    places[place].IsEnabled = false;
                    moves++;
                    break;
                }
            }
        }
        private void Move(object sender)
        {
            //one possible way to find out the index of the button
            Button b = (Button)sender;
            b.IsEnabled = false;
            //int place = 0;
            //while (true)
            //{
            //    if (slots[place] == b)

            //        break;
            //    place++;
            //}

            //prevent the other marks
            //slots[place].IsEnabled = false;
            b.Content = "X";
            moves++;

        }
        private string Check()
        {
            string Winner = "";

            for (int i = 0; i < 9; i++)
            {
                if ((i == 0) || (i == 3) || (i == 6))
                    if (((places[i].Content.ToString() == places[i + 1].Content.ToString()) &&
                    (places[i].Content.ToString() == places[i + 2].Content.ToString()) &&
                    (places[i].Content.ToString() != "")))
                    {
                        Winner = places[i].Content.ToString();
                    }
                    else if (((places[i].Content.ToString() == places[(i + 3) % 9].Content.ToString()) &&
                      (places[i].Content.ToString() == places[(i + 6) % 9].Content.ToString()) &&
                      (places[i].Content.ToString() != "")))
                    {
                        Winner = places[i].Content.ToString();
                    }
                    else if (((places[i].Content.ToString() == places[(i + 4) % 9].Content.ToString()) &&
                         (places[i].Content.ToString() == places[(i + 8) % 9].Content.ToString()) &&
                         (places[i].Content.ToString() != "")))
                    {
                        Winner = places[i].Content.ToString();
                    }
                    else if (((places[i].Content.ToString() == places[(i + 5) % 9].Content.ToString()) &&
                         (places[i].Content.ToString() == places[(i + 7) % 9].Content.ToString()) &&
                         (places[i].Content.ToString() != "")))
                    {
                        Winner = places[i].Content.ToString();
                    }
                if ((i == 1) || (i == 2))
                    if (((places[i].Content.ToString() == places[i + 1].Content.ToString()) &&
                    (places[i].Content.ToString() == places[i + 2].Content.ToString()) &&
                    (places[i].Content.ToString() != "")))
                    {
                        Winner = places[i].Content.ToString();
                    }
                    else if (((places[i].Content.ToString() == places[(i + 3) % 9].Content.ToString()) &&
                      (places[i].Content.ToString() == places[(i + 6) % 9].Content.ToString()) &&
                      (places[i].Content.ToString() != "")))
                    {
                        Winner = places[i].Content.ToString();
                    }
                    else if (((places[i].Content.ToString() == places[(i + 4) % 9].Content.ToString()) &&
                         (places[i].Content.ToString() == places[(i + 8) % 9].Content.ToString()) &&
                         (places[i].Content.ToString() != "")))
                    {
                        Winner = places[i].Content.ToString();
                    }
                    else if (((places[i].Content.ToString() == places[(i + 5) % 9].Content.ToString()) &&
                         (places[i].Content.ToString() == places[(i + 7) % 9].Content.ToString()) &&
                         (places[i].Content.ToString() != "")))
                    {
                        Winner = places[i].Content.ToString();
                    }
                if ((i == 4))
                    if (((places[i].Content.ToString() == places[i + 1].Content.ToString()) &&
                    (places[i].Content.ToString() == places[i + 3].Content.ToString()) &&
                    (places[i].Content.ToString() != "")))
                    {
                        Winner = places[i].Content.ToString();
                    }
                    else if (((places[i].Content.ToString() == places[(i + 3) % 9].Content.ToString()) &&
                      (places[i].Content.ToString() == places[(i + 6) % 9].Content.ToString()) &&
                      (places[i].Content.ToString() != "")))
                    {
                        Winner = places[i].Content.ToString();
                    }
                    else if (((places[i].Content.ToString() == places[(i + 4) % 9].Content.ToString()) &&
                         (places[i].Content.ToString() == places[(i + 8) % 9].Content.ToString()) &&
                         (places[i].Content.ToString() != "")))
                    {
                        Winner = places[i].Content.ToString();
                    }
                    else if (((places[i].Content.ToString() == places[(i + 5) % 9].Content.ToString()) &&
                         (places[i].Content.ToString() == places[(i + 7) % 9].Content.ToString()) &&
                         (places[i].Content.ToString() != "")))
                    {
                        Winner = places[i].Content.ToString();
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
                places[i].Content = "";
                places[i].IsEnabled = true;
                moves = 0;
            }
        }


    }
}


