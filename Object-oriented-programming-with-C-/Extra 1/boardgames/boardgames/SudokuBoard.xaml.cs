using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace boardgames
{
    /// <summary>
    /// Interaction logic for SudokuBoard.xaml
    /// </summary>
    public partial class SudokuBoard : UserControl
    {
        private Sudoku sudoku;

        private int slots = 9 * 9;
        public SudokuBoard()
        {
            InitializeComponent();
            sudoku = new Sudoku(this);
            //sudoku.NewGame(); 

        }
        //public void Init()
        //{
        //    grid.Children.Clear();
        //    int i = 0;
        //    while (i++ < slots)
        //    {
        //        ComboBox places = new ComboBox();
        //        //sudoku.Empty(ComboBox) we will decide later 

        //        grid.Children.Add(places);
        //        foreach (string s in sudoku.items)
        //        {
        //            places.Items.Add(s);
        //        }

        //    }

        //}
        public void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            sudoku.Play(sender); 
            


        }
    }
}
