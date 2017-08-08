using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Memory_only
{
    class Board : IBoard, IControl
    {
        /// <summary>
        /// Board in the UI
        /// </summary>
        private UniformGrid board;
        /// <summary>
        /// size of board 4x4, 6x6, 8x8, 10X10, 12X12
        /// </summary>
        private int places;
        /// <summary>
        /// place to show results
        /// </summary>
        private TextBlock result;
        /// <summary>
        /// the game that is played
        /// </summary>
        private MemoryGame game;

        /// <summary>
        /// first button turned
        /// </summary>
        private Button first;
        /// <summary>
        /// second button turned
        /// </summary>
        private Button second;
        /// <summary>
        /// true, if the buttons are pair
        /// </summary>
        private bool isPair;
        /// <summary>
        /// true, is all pairs are found or show has been called
        /// </summary>
        private bool isReady;

        /// <summary>
        /// file to serialize game
        /// </summary>
        private string file = "state.dat";
        /// <summary>
        /// constructor that deserializes or starts a new game
        /// </summary>
        /// <param name="uniformGrid"></param>
        /// <param name="result"></param>
        /// <param name="places"></param>
        /// <param name="rbs"></param>
        public Board(UniformGrid uniformGrid, TextBlock result, int places, Grid rbs)
        {
            this.board = uniformGrid;
            this.result = result;
            if (File.Exists(file) && MessageBox.Show("Do you want to continue with the previous game?", "Continue?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                State(true); //game is restored
                switch (this.places) //restore UI radiobutton
                {
                    case 4: ((RadioButton)rbs.Children[0]).IsChecked = true; break;
                    case 6: ((RadioButton)rbs.Children[1]).IsChecked = true; break;
                    case 8: ((RadioButton)rbs.Children[2]).IsChecked = true; break;
                    case 10: ((RadioButton)rbs.Children[3]).IsChecked = true; break;
                    case 12: ((RadioButton)rbs.Children[4]).IsChecked = true; break;
                    default: ((RadioButton)rbs.Children[0]).IsChecked = true; break;
                }
            }
            else
            {
                InitBoard(places);
            }
        }
        /// <summary>
        /// resets Board and game (empty content)
        /// </summary>
        public void Reset()
        {
            this.board.Children.Clear();
            InitBoard();
            if (game != null)
                game.Reset();
            State(false);
        }
 
        /// <summary>
        /// initialized all the buttons in the GUI Board
        /// </summary>
        public void InitBoard()
        {
            for (int i = 0; i < places * places; i++)
            {
                Button b = new Button();
                //add button into Uniform grid in UI
                this.board.Children.Add(b);
                //add content 
                b.Content = Markers.Empty;
                //add event to button using delegate buttonClick
                b.Click += ButtonClick;
            }
        }

        /// <summary>
        /// initialize board, textBlock and places and then call reset and initialization 
        /// </summary>
        /// <param name="amount">amount of places, selected with radiobuttons</param>
        public void InitBoard(int amount)
        {
                this.places = amount;
                game = new MemoryGame(amount);
                Reset();
        }

        /// <summary>
        /// the main action - user presses a button when placing the mark
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Button b = (Button)sender;
            //if two buttons are turned and they are not pair
            if (!isPair && first != null && second != null)
            {
                first.Content = second.Content = Markers.Empty;
                first.IsEnabled = true;
                second.IsEnabled = true;
                first = second = null;
            }
            //two buttons are turned and they are a pair
            else if (isPair && first != null && second != null)
            {
                first = second = null;
                isPair = false;
            }
            //show the content 
            b.Content = game.Content(board.Children.IndexOf(b));
            State(false);
            //if the button is the first of a pair
            if (first == null)
            {
                first = b;
                first.IsEnabled = false;
            }
            //if the button is the second of the pair
            else if (second == null)
            {
                second = b;
                second.IsEnabled = false;
                //is the content the same
                int i =  board.Children.IndexOf(first);
               int j =   board.Children.IndexOf(second);
               if (i < 0 || j < 0 || i == j)
               {
                   MessageBox.Show("Not so fast, please", "UUPS");
               }
               else if (game.isPair(i, j))
                {
                    State(false);
                    isPair = true;
                    isReady = true;
                    //are all buttons turned
                    foreach (var v in board.Children)
                    {
                        if (((Button)v).IsEnabled)
                            isReady = false;
                    }
                    //if all buttons are turned 
                    if (isReady)
                    {
                        State(false);
                        MessageBox.Show("You managed to find all pairs!", "Well done", MessageBoxButton.OK);
                        Reset();
                    }
                }
            }  
        }

        /// <summary>
        /// shows all pairs in the board and disables buttons
        /// </summary>
        public void Show()
        {
            for (int i = 0; i < places * places; i++)
            {
                ((Button)board.Children[i]).Content = game.Content(i);
                board.Children[i].IsEnabled = false;
            }
        }
        
        /// <summary>
        /// displayes statistics and deserialized or serialized the game
        /// 
        /// </summary>
        /// <param name="deserialize">true deserialize, false serialize</param>
        public void State(bool deserialize) 
        {
            //deserialize game from a file
            if (deserialize)
            {
                FileStream fin;
                BinaryFormatter bf;
                bf = new BinaryFormatter();
                fin = File.Open(file, FileMode.Open, FileAccess.Read);
                game = (MemoryGame)bf.Deserialize(fin);
                fin.Close();
                //restore the state of board
                places = game.Places;
                InitBoard();
                for (int i = 0; i < places * places; i++)
                {
                    int j;
                    char mark = game.Found(i, out j);
                    if (j >= 0 && mark != Markers.Empty)
                    {
                        ((Button)board.Children[i]).Content = mark;
                        ((Button)board.Children[j]).Content = ((Button)board.Children[i]).Content;
                        board.Children[i].IsEnabled = false;
                        board.Children[j].IsEnabled = false;
                    }
                }
            }
            else   //serialize the state to a file
            {
                FileStream fout;
                BinaryFormatter bf;
                bf = new BinaryFormatter();
                fout = File.Open(file, FileMode.OpenOrCreate, FileAccess.Write);
                bf.Serialize(fout, game);
                fout.Flush();
                fout.Close();
            }
            result.Text = game.Statistics();
        }

        public void Set()
        {
            for (int i = 0; i < places; i++)
            {
                
                ((Button)board.Children[i]).Content = game.Content(i);
                board.Children[i].IsEnabled = false;
            }
        }
    }
}
