using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace exercise_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CommandHandler cmhandler = new CommandHandler();
        //private ReadWrite ReadWrite = new ReadWrite();
        //private ReadWriteDialog ReadWriteDialog = new ReadWriteDialog(); 

        public MainWindow()
        {
            InitializeComponent();
            cmhandler.Window = this; //Set the Window Property 
        }

        /****allowing menuitems and buttons to be visible all the time****/
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        /****actual commands to be executed****/
        private void New_CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) //New
        {
            text.IsEnabled = true;
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
            cmhandler.Close(); 
        }

    }
}
