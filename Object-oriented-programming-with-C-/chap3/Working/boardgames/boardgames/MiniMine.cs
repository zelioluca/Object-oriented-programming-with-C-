﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace boardgames
{
    public class MiniMine
    {
        public const int row=6;
        public const int AmontOfButtons = row * row;
        public const int amountofMines = 10;
        private const string mine = "*";
        public const string Empty = "";
        protected Button[] places = new Button[AmontOfButtons];
        private string[] content = new string[AmontOfButtons];
        private int[] mineInfo = new int[AmontOfButtons];
        private int points;
        private int emptySpace = AmontOfButtons - amountofMines;
        private List<int> mines = new List<int>(amountofMines);
        private int count;
        string[,] table = new string[row, row];
        private MineBoard board;

        public MiniMine()
        { }

        public MiniMine(UserControl grid)
        {
            this.board = (MineBoard)grid;
            board.alusta.Children.CopyTo(places, 0);
            Init();
            //PlaceMine();  
        }
        public void Init()
        {

            places = new Button[AmontOfButtons];
            board.alusta.Children.CopyTo(places, 0);
            content = new string[AmontOfButtons];

           
            //for(int i = 0; i <AmontOfButtons; i++)
            //{
            int i = 0;
            if (i <= amountofMines)
            {
                content[i] = mine;
                //places[i].Content = mine; 
                i++;
            }
            else
            {
                content[i] = Empty;
                
            }
            //}

            PlaceMines();
            makeTable();
        }
        void makeTable()
        {
            int num = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j< row; j++)
                {
                    table[i, j] = content[num];
                    num++;
                }
            }
            
        }
        public void Play(object sender)
        {
            Button b = (Button)sender;
            int index = board.alusta.Children.IndexOf(b);
            if (content[index] == mine)
            {
                ShowMine();

                MessageBox.Show("You get the mine, Another one?", "Looser", MessageBoxButton.OK);

                if (MessageBox.Show("New game?", "Game", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Init();

                }
                else
                {
                    Application.Current.Shutdown();
                }
            }
            else if (content[index] == Empty)
            {
                places[index].IsEnabled = false;
                
            }
            //disable the selected button 
            b.IsEnabled = false;
            ShowMineInfo(index);
            points++;
            emptySpace--;
            //MessageBox.Show(emptySpace.ToString());
            if (emptySpace == 0)
            {
                MessageBox.Show("Clear", "Winner", MessageBoxButton.OK);

                if (MessageBox.Show("New game?", "Game", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Init();

                }
                else
                {
                    Application.Current.Shutdown();
                }
            }

            //if user hit the mine show all miness 
            //check if there was a minemine 
            // else show the amount of mines in neighbouring buttons, some of the buttons are visited several times 
            //if all available buttons are turned or user hot the mine announce the situation and ask if user wants a new game 

        }
        public void PlaceMines()
        {
            //pick places for mines 
            Random p = new Random();
            int num = 0;
            int mineNum = amountofMines;
            //for (int count = 0; count <= amountofMines; count++)
            while(true)
            {
                int luca = p.Next(1, AmontOfButtons);
                if (content[luca] == "*")
                {
                    
                }
                else {
                    /*places[luca].Content = mine;
                    content[luca] = mine;
                    places[luca].IsEnabled = true;*/
                    content[luca] = "*";
                    places[luca].IsEnabled = true;
                    mineNum--;
                    if (mineNum == 1)
                    {
                        break;
                    }
                }
            }
            
            Reset();
        }


        //show all mines  
        public void ShowMine()
        {
            for (int i = 0; i < AmontOfButtons; i++)
            {
                if (content[i] == mine)
                {

                    places[i].IsEnabled = false;
                    places[i].Content = mine;
                }
            }

        }

        //how many mines a button sees 
        //row -1, +1 
        //column -1, +1 
        //coners row = cloumn -1, +1 
        private int MineInfo(int index)
        {
            return 0;
        }

        private void ShowMineInfo(int index)
        {
            count = 0;
            int x, y;
            int firstRow = 0, firstColumn = 0;
            int startRow = -1, startColumn = -1;
            int endRow = 2, endColumn = 2;
            int lastRow = 1, lastColumn = 1;
            x = index / 6;
            y = index % 6;
            //show amount in surrounding buttons 
            if(x == 0)
            {
                if(y==0)
                {
                    // row, column, start row, start column, end row, end column
                    MineChecker(x, y, firstRow, firstColumn, endRow, endColumn);  //1st row and 1st column
                }
                else if (y == 5)
                {
                    MineChecker(x, y, firstRow, startColumn, endRow, lastColumn);  //1st row and last column
                }
                else
                {
                    MineChecker(x, y, firstRow, startColumn, endRow, endColumn);       //1st row and any column
                }
            }
            else if (x == 5)
            {
                if (y == 0)
                {
                    MineChecker(x, y, startRow, firstColumn, lastRow, endColumn);  //last row and 1st column
                }
                else if (y == 5)
                {
                    MineChecker(x, y, startRow, startColumn, lastRow, lastColumn);  //last row and last column
                }
                else
                {
                    MineChecker(x, y, startRow, startColumn, lastRow, endColumn);  //last row and any column
                }
            }
            else
            {
                if (y == 0)
                {
                    MineChecker(x, y, startRow, firstColumn, endRow, endColumn);  //any row and 1st column
                }
                else if (y == 5)
                {
                    MineChecker(x, y, startRow, startColumn, endRow, lastColumn);  //any row and last column
                }
                else
                {
                    MineChecker(x, y, startRow, startColumn, endRow, endColumn);  //any row and any column
                }
            }
         
            places[index].Content = count.ToString();
        }
        private void MineChecker(int x, int y, int rS, int cS, int rE, int cE)
        {
            for (int i = rS; i < rE; i++)
            {
                for (int j = cS; j < cE; j++)
                {
                    if (table[x + i, y + j] == "*")
                    {
                        count++;
                    }
                }
            }
        }
        private void Reset()
        {
            for (int i = 0; i < AmontOfButtons; i++)
            {
                places[i].IsEnabled = true;
            }
        }

    }
}
