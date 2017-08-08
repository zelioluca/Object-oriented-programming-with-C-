using System.Windows;
using System.Windows.Input;

namespace exercise_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CommandHandler cmhandler = new CommandHandler();

        public MainWindow()
        {
            InitializeComponent();
            cmhandler.window = this; //Set the Window Property 
        }

        /****allowing menuitems and buttons to be visible all the time****/
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        /****actual commands to be executed****/
        private void New_CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) //New
        {
            cmhandler.New(); 
        }

        private void Open_CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) //Open
        {
            cmhandler.Open();
        }

        private void Save_CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) //Save
        {
            cmhandler.Save(true);

        }

        private void SaveAs_CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) //SaveAs
        {
            cmhandler.Save(false);

        }

        private void Close_CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) //Close
        {

        }

    }
}
