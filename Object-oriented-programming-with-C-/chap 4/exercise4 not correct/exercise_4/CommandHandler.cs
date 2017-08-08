using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;

namespace exercise_4
{
    /// <summary>
    /// Actually handles the commands passed from MainWindow
    /// </summary>
    class CommandHandler
    {
        private string defaultfileName = "noname.txt";
        private string fileName;
        
        private ReadWriteDialog ReadWriteDialog = new ReadWriteDialog(); 
        public MainWindow Window { get ; set ; } //propery without field in this case is enough

        /// <summary>
        /// File in not created,
        /// window title is defaultfileName,
        /// textarea is cleared and enabled,
        /// does not check if there already is text possible to be saved.
        /// </summary>

        
        public void New()
        {
            EnableEditing();
            fileName = defaultfileName;
            Window.Title = fileName;
            Window.text.Document.Blocks.Clear();
        }

        /// <summary>
        /// Textarea is cleared and enabled,
        /// does not check if there already is text possible to be saved,
        /// calls OpenReadFile in ReadWriteDialog class.
        /// Does not check if there already is text that might be saved prior opening new file.
        /// </summary>
        public void Open()
        {
            Window.text.Document.Blocks.Clear();

           
           // ReadWriteDialog.ReadFile(filename);

            
        }

        /// <summary>
        /// Selects all text in textarea, 
        /// calls WriteFile or WriteFileAs in 
        /// ReadWriteDialog class.
        /// </summary>
        /// <param name="isname">true = file has a name and WriteFile is called, 
        /// false = file has no name and WriteFileAs is called</param>
        public void Save(bool isname)
        {
            Window.text.SelectAll();
            
            string whatToSave = Window.text.Selection.Text;
            try
            {

             ReadWriteDialog.WriteFileAs(whatToSave);
               
            }
            catch (Exception)
            {
                MessageBox.Show("Can t save Master");
            }
        }

        /// <summary>
        /// Closes the window given a a property,
        /// asks if the text in textarea should be saved before closing,
        /// if the file already has a name WriteFile is called, if not WriteFileAs is called in 
        /// ReadWriteDialog class.
        /// </summary>
        public void Close()
        {
            Window.text.SelectAll();
            string whatToSave = Window.text.Selection.Text;
            //nothing to save
            if (Window.text.IsEnabled == false || whatToSave.Length == 0)
            {
                Window.Close();
            }
            else
            {
                
            }
        }

        /// <summary>
        /// If no file or new document is selected
        /// the textarea is not enabled.
        /// </summary>
        private void EnableEditing()
        {
            if (Window.text.IsEnabled == false)
                Window.text.IsEnabled = true;
        }
    }
}
