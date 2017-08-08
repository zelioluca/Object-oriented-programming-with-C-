using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;


namespace boardgames
{
    public class MiniMine : pelitkirijasto.BoardGame
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

        private List<int> mines = new List<int>(amountofMines);

        private MineBoard board;



        public MiniMine()
        {

        }
        public MiniMine(UserControl grid)
        {
            this.board = (boardgames.MineBoard)grid;
            board.alusta.Children.CopyTo(places, 0);
            Init();
        }

        new public void Init()
        {
            PlaceMines();
        
            
        }
        new public void Play(object sender)
        {
            Button b = (Button)sender;
            int index = board.alusta.Children.IndexOf(b);
            b.IsEnabled = false;
            points++;

            //if user hit the mine show all miness 
            //check if there was a minemine 
            // else show the amount of mines in neighbouring buttons, some of the buttons are visited several times 
            //if all available buttons are turned or user hot the mi
            //e announce the situation and ask if user wants a new game
        }
        private void PlaceMines()
        {
            Random p = new Random(); //ref of number of mine not place! 

            for (int count = 0; count <= 10; count++)
            {
               int luca = p.Next(1, 36);
               
                places[luca].Content = mine;
                places[luca].IsEnabled = true;
                
              
                    
                     
            }
           
        }

        //show all mines  
        private void ShowMine()
        {
        }

        //how many mines a button sees 
        //row -1, +1 
        //column -1, +1 
        //coners row = cloumn -1, +1 
        //private int MineInfo(int index)
        //{
        //   // return amount;
        //}

        private void ShowMineInfo()
        {
            //show amount in surrounding buttons 
        }

    }
}
