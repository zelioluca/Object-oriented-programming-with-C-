using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pelitkirijasto;
using System.Windows.Controls;

namespace BoardGame
{
    class MiniMine: pelitkirijasto.BoardGame
    {
        private const int row = 6;
        public const int AmontOfButtons = row * row;
        private const int amountofMines = 10;
        private const string mine = "*";
        public const string Empty = "";
        protected new Button[] places = new Button[AmontOfButtons];
        private string[] content = new string[AmontOfButtons];
        private int[] mineInfo = new int[AmontOfButtons];
        private int points;
        List<int> result = new List<int>();
        private List<int> mines = new List<int>(amountofMines);

        private MineBoard board;

        public MiniMine()
        { }
        public MiniMine(UserControl grid)
        {
            this.board = (BoardGame.MineBoard)grid;
            board.grid.Children.CopyTo(places, 0);
            Init();
            
        }

        
         new public void  Init()
        {
            places = new Button[AmontOfButtons];
            board.grid.Children.CopyTo(places, 0);
            PlaceMines();
                
            
            
        }
        
       new public void Play(object sender)
        {
            Button b = (Button)sender;
            int index = board.grid.Children.IndexOf(b);
            //disable the selected button 
            b.IsEnabled = false;
            points++;
            if(b.IsEnabled == true && b.Content !=null) //if user hit the mine show all miness 
            {
                ShowMine(); 
            }
           
            //check if there was a minemine 
            // else show the amount of mines in neighbouring buttons, some of the buttons are visited several times 
            //if all available buttons are turned or user hot the mine announce the situation and ask if user wants a new game 


        }
        private void PlaceMines()
        {
            
            for(int i=0; i< amountofMines; i++)
            {
               
                places[i].Content = "*";
                places[i].IsEnabled = true;

                
             
            }
            
           
        }

        //show all mines  
        private void ShowMine() //to do
        {
          for(int i=0; i< amountofMines; i++)
            {
                if(places[i].IsPressed && places[i].Content !=null)
                {
                   
                    places[i].Content.ToString();
                    
                    
                }
            }
            
         
        }

        //how many mines a button sees 
        //row -1, +1 
        //column -1, +1 
        //coners row = cloumn -1, +1 
        private int MineInfo(int index)
        {
            return amountofMines;
        }

        private void ShowMineInfo()
        {
            //show amount in surrounding buttons 
        }
    }
} 
 
    

