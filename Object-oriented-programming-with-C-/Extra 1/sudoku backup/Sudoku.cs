using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using pelitkirjasto;

namespace boardgames
{
    class Sudoku : BoardGame
    {

        //does not use inherited slots table  
        //but HAS it anyway 
        //message shows how many numbers still need to be quessed 
        private string message = "Sudoku";
        //how many numbers there is in each row or column 
        private const int amount = 9;
        public const int amouuntOfCombo = amount * amount;
        protected new ComboBox[] places = new ComboBox[amouuntOfCombo];
        //combobox choices 
        public string[] items = new String[] { " ", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        //covering patters where 1 stads for combobox and 0 for label  
        private int[] pattern = new int[]{
                                            1,1,0,0,1,0,0,0,0,
                                            1,0,0,1,1,1,0,0,0,
                                            0,1,1,0,0,0,0,1,0,
                                            1,0,0,0,1,0,0,0,1,
                                            1,0,0,1,0,1,0,0,1,
                                            1,0,0,0,1,0,0,0,1,
                                            0,1,0,0,0,0,1,1,0,
                                            0,0,0,1,1,1,0,0,1,
                                            0,0,0,0,1,0,0,1,1 };
        private int correct;
        //to obtain a random line from the data.dat file 
        private Random random = new Random();
        //contains the numbers  
        private string[] data = new string[amouuntOfCombo];
        //name of the file that contains a sudoku in each row numbers separated with comma 
        private string filename = "data.dat";
        //how many numbers are left to be quessed 
        private int points;
        //gameboard
        private SudokuBoard gameboard;

        public Sudoku(SudokuBoard grid)
        {
            this.gameboard = grid;
            NewGame();
        }
        // inherited new implementation
        new public void NewGame()
        {
            gameboard.grid.Children.Clear();
            
            ReadSudoku(random.Next(0, 4));
            Init();
        }
        /// reads a random line from a file 
                /// if the random line is bigger than the amount of lines the reading starts from the beginning again 

        private void ReadSudoku(int line)
        {
            try
            {
                string readLine = File.ReadLines("D:\\(D)Download\\luca14.10last\\boardgames\\data.dat").Skip(line).Take(1).First();
                data = readLine.Split(',').ToArray();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());

                data = new string[] { "5", "3", "4", "6", "7", "8", "9", "1", "2",
                                     "6", "7", "2", "1", "9", "5", "3", "4", "8",
                                     "1", "9", "8", "3", "4", "2", "5", "6", "7",
                                     "8", "5", "9", "7", "6", "1", "4", "2", "3",
                                     "4", "2", "6", "8", "5", "3", "7", "9", "1",
                                     "7", "1", "3", "9", "2", "4", "8", "5", "6",
                                     "9", "6", "1", "5", "3", "7", "2", "8", "4",
                                     "2", "8", "7", "4", "1", "9", "6", "3", "5",
                                     "3", "4", "5", "2", "8", "6", "1", "7", "9" };
            }
            //open file for reading
            //how many lines there are in the file  (row is one 9*9 sudoku) 
            //read line by line until the correct is reached 
            //if reading failed then use default 
        }
        public new void Play(object sender)
        {
            
            ComboBox item = (ComboBox)sender;
            int index = gameboard.grid.Children.IndexOf(item);
            //if the selected value is the corect one change combobox to label 
            //and background to beige 
            //and check if the game is over 
            points += 1;
            if (item.SelectedItem.ToString() == data[index])
            {
                item.IsEnabled = false;
                correct -= 1;
            }
            //MessageBox.Show(correct.ToString());
            if (correct == 0)
            {
                MessageBox.Show("You clear game with " + (points).ToString() + " tries!");

            }
        }
        /// <summary> 
                /// inherited and overriden method to create comboboxes and labels 
                /// and reset points 
                /// </summary> 
        new public void Init()
        {
            points = 0;
            correct = 0;
            for (int i = 0; i < amouuntOfCombo; i++)
            {
                if (pattern[i] == 1)
                {
                    correct += 1;
                }
            }
            for (int i = 0; i < amouuntOfCombo; i++)
            {
                if (pattern[i] == 1)
                {
                    ComboBox cb = new ComboBox();
                    gameboard.grid.Children.Add(cb);
                    cb.SelectionChanged += new                      // Add event handler to combobox 
                        SelectionChangedEventHandler(gameboard.SelectionChanged);
                    foreach (string s in items)
                        cb.Items.Add(s);
                }
                else
                {

                    Label lab = new Label();
                    gameboard.grid.Children.Add(lab);
                    lab.Content = data[i]; // adds the numbers in the places that are not buttons
                }
            }
        }
    }
}
