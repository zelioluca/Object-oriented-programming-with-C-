using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BoardGames
{
    public class MineMine
    {
        private const int row = 6;
        private const int col = 6;
        public const int AmontOfButtons = row * col;
        private const int amountofMines = 10;
        private const string mine = "*";
        public const string Empty = "";
        protected new Button[] places = new Button[AmontOfButtons];
        private string[] content = new string[AmontOfButtons];
        private int[] mineInfo = new int[AmontOfButtons];
        private int points;

        private List<int> mines = new List<int>(amountofMines);

        private MineBoard board;

        public MineMine()
        { }

        public MineMine(UserControl grid)
        {
            this.board = (MineBoard)grid;
            board.alusta.Children.CopyTo(places, 0);
            Init();
            PlaceMines();

        }
       
        public  void Init()
        {
            places = new Button[AmontOfButtons];
            board.alusta.Children.CopyTo(places, 0);
            content = new string[AmontOfButtons];
            for (int i = 0; i < AmontOfButtons; i++)
            {
                if (i <= amountofMines)
                {
                    content[i] = mine;
                    places[i].Content = mine; 
                }
                else
                    content[i] = Empty; 
                    
            }
                
          
        }

        public bool Play(object sender)
        {
            bool end = false; 

            Button places = (Button)sender;
            int index = board.alusta.Children.IndexOf(places);
            //disable the selected button 
            places.IsEnabled = false;
            points++;
            //if user hit the mine show all miness 
            //check if there was a minemine 
            // else show the amount of mines in neighbouring buttons, some of the buttons are visited several times 
            //if all available buttons are turned or user hot the mine announce the situation and ask if user wants a new gam
            ShowMine(); 
            if (content[index] == "*")
            {
                MessageBox.Show("You get the mine (if I can put the content inside the button, Another one?", "Looser", MessageBoxButton.OK);

                if (MessageBox.Show("New game?", "Game", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Init();
                    PlaceMines();
                    
                }
                else
                {
                    end = true;
                    Application.Current.Shutdown(); 
                }
    
            }
            return end; 
        }
        private void PlaceMines()
        {
            Random p = new Random(); //ref of number of mine not place! 

            for (int count = 0; count <= 10; count++)
            {
                int luca = p.Next(1, AmontOfButtons);

                places[luca].Content = mine;
                content[luca] = mine; 
                places[luca].IsEnabled = true;

            }
          for(int i=0; i<AmontOfButtons; i++)
            {
                places[i].IsEnabled = true; 
            }



        }

        //show all mines  
        private void ShowMine()
        {
           
            for(int i=0; i<col; i++)
            {
                for(int y=0; y<col; y++)
                {
                    if((i==0) || (i==1) || (i==2) || (i==3) || (i==4) || (i==5))
                    {
                        if(content[i].Contains(mine))
                        {
                            places[i].IsEnabled = false; 
                        }
                    }
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

        private void ShowMineInfo()
        {
            //show amount in surrounding buttons 
        }


    }
}