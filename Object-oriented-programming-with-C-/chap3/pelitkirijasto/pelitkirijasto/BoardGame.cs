using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace pelitkirijasto
{
    
    public abstract class BoardGame: IBoardGame
    {
        protected UIElement[] places;

     
       public void Init()
        { }        
            
        

        public void NewGame()
        { }

        public void Play(object sender)
        { }
        
       

        
    }


} 
          
    
   

