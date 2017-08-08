using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives; 
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace tictactoe
{
    [Serializable]

     public  class TicTacToe
    {   //copy of buttons in the user interface
        [NonSerialized] public Button[] slots = new Button[9]; 
        //ammount of moves in one game
        private int moves;
        private string file = "serialize.dat";
        // public TicTacToe game; 
        string[] testArray = new string[9];

 
        public TicTacToe(TTTBoard tTTBoard)
        {
            //copy the reference of the buttons in Grid named grid to slots table
            tTTBoard.grid.Children.CopyTo(slots, 0);
            Initialize();
            if (File.Exists(file) && MessageBox.Show("Do you want to continue the game?", "continuing", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            State(true); 
        }
        //<summary>
        //make a move and machine's counter move
        //</summary>
        //<param name ="sender">button where the eventwas raised</param>
        internal void Play(object sender)
        {
            //message shows user the situation of the game
            string message = "";
            //user move
            Move(sender);

            if(AnnounceSituation(Check(), ref message)) //has the game ended?
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
        private void NewGame(string message)
        {
            if (MessageBox.Show("Do you want to start a new game", message, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Initialize();
            }
            else
            {
                Application.Current.Shutdown(); 
                   
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
                    //testArray[place] = "O";
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
            b.Content = "X";
            
            moves++;
            
        }
        private string Check()
        {
            string Winner = "";
           
            for (int i = 0; i < 9; i++)
            {
                testArray[i] = slots[i].Content.ToString();
                State(false);

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
                if((i == 1) || (i== 2))
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
        private void ToArray()
        {
            for(int i= 0; i<9; i++)
            {
                testArray[i] = slots[i].Content.ToString(); 
            }
            
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
                ToArray();

                
            }
        }
        
        public void State(bool deserialize)
        {
            if (deserialize)
            {
                FileStream fin;
                BinaryFormatter bf = new BinaryFormatter();
                fin = File.Open(file, FileMode.Open, FileAccess.Read);
                TicTacToe tic = (TicTacToe)bf.Deserialize(fin); //hereeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
                fin.Close();
                
                Initialize();
                for (int i = 0; i < 9; i++)
                {
                    slots[i].Content = tic.testArray[i];       
                }
            }
            else
            {

                FileStream fout;
                BinaryFormatter bf;
                bf = new BinaryFormatter();
                fout = File.Open(file, FileMode.OpenOrCreate, FileAccess.Write);
                TicTacToe tic = this;
                bf.Serialize(fout,  tic);
                fout.Flush();
                fout.Close();
            }
            }

    }
}
