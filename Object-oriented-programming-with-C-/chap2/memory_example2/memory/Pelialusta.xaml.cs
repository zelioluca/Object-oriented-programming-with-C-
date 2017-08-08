using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace memory
{
    /// <summary>
    /// Interaction logic for MemoryBoard.xaml
    /// </summary>
    public partial class MemoryBoard : UserControl
    {

        private MemoryGame game;
        //amount of slots in the board 4x4, 6x6, 8x8, 10X10
        private int slots = 4 * 4;

        public MemoryBoard()
        {
            InitializeComponent();
            game = new MemoryGame(this);
            game.NewGame();
        }

        public void Init()
        {
            //empty the grid from any previous element
            grid.Children.Clear();
            int i = 0;
            while (i++ < slots)
            {
                //create a new cnavas
                Canvas canvas = new Canvas();
                game.Empty(canvas);
                //add event to the canvas
                canvas.MouseLeftButtonDown += new MouseButtonEventHandler(b_MouseLeftButtonDown);
                //add the canvas into the board grid
                grid.Children.Add(canvas);
            }
        }

        /// <summary>
        /// handle canvas events
        /// </summary>
        private void b_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (game.Pelaa(sender))
            {
                //get the window where this element resides to close the complete program 
                //huom! implisite type definition var
                var myWindow = Window.GetWindow(this);
                myWindow.Close();
            }
        }
        /// <summary>
        ///show everything button
        /// </summary>
        private void Show_Click(object sender, RoutedEventArgs e)
        {
            game.Show();
            result.Text = "Start a new game";
        }
        ///<summary>
        /// tstart a new game button
        ///</summary>
        private void New_Click(object sender, RoutedEventArgs e)
        {
            game.NewGame(slots);
        }

        ///<summary>
        /// select the size of the game
        /// and also start a new game
        ///</summary>
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (game != null)
            {
                RadioButton rb = (RadioButton)sender;
                switch (rb.Content.ToString())
                {
                    case "4x4": slots = 4 * 4;
                        break;
                    case "6x6": slots = 6 * 6;
                        break;
                    case "8x8": slots = 8 * 8;
                        break;
                    case "10x10": slots = 10 * 10;
                        break;
                    default: slots = 4 * 4;
                        break;
                }
                game.NewGame(slots);
            }
        }
    }
}
