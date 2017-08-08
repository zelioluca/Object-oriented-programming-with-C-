using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using exercise5;
using System.Windows.Media;

namespace exercise5
{
    class Data
    {
        //List list = new List(); 

        //List<List>MasterList { get; set; }
       public static  List<List> MasterList = new List<List>();
        public static List<string[]> textForGrid { get; set; }

        public MainWindow window { get; set; }
       
        public void Convertion(List<string[]>textForGrid)
        {
            int i = 0;
            foreach (var v in textForGrid)
            {
                uint firstVal = UInt16.Parse(textForGrid[i][0]);


                double secondVal = double.Parse(textForGrid[i][1]);


                MasterList.Add(new List(firstVal, secondVal, textForGrid[i][2]));
                i++;
            }
         
        }
        public void gridFill(MainWindow window, List<string[]>textForGrid)   //working perfectly
        {
            Convertion(textForGrid);

            var source = new BindingSource();
            source.DataSource = MasterList;
            window.dataGrid1.ItemsSource = source;


        }
        public List<List>Superfunction(List<List>MasterList)
        {
            return MasterList; 
        }
        
        

    }
   
       

}
