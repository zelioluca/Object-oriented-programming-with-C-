using System;
using System.Collections.Generic;
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

        ReadWriteDialog ReadWriteDialog = new ReadWriteDialog();
        ReadWrite ReadWrite = new ReadWrite();
        public MainWindow window { get; set; } //propery without field in this case is enough
        public string text { get; set; }
        public string whatToSave { get; set; }





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
            window.Title = fileName;
            window.text.Document.Blocks.Clear();
        }

        /// <summary>
        /// Textarea is cleared and enabled,
        /// does not check if there already is text possible to be saved,
        /// calls OpenReadFile in ReadWriteDialog class.
        /// Does not check if there already is text that might be saved prior opening new file.
        /// </summary>
        public void Open()
        {
            window.text.Document.Blocks.Clear();
            //string contents;
            try
            {
               text= ReadWriteDialog.ReadFile(window, out fileName);

                window.text.AppendText(text);
                window.Title = fileName; 
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

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
             window.text.SelectAll();
            
            ReadWriteDialog.WriteFile(fileName, isname);


        }

        /// <summary>
        /// Closes the window given a a property,
        /// asks if the text in textarea should be saved before closing,
        /// if the file already has a name WriteFile is called, if not WriteFileAs is called in 
        /// ReadWriteDialog class.
        /// </summary>
        public void Close()
        {
            window.text.SelectAll();
            string whatToSave = window.text.Selection.Text;
            //nothing to save
            if (window.text.IsEnabled == false || whatToSave.Length == 0)
            {
                window.Close();
            }
            else
            {
                if (MessageBox.Show("Do you want to save?", "Exercise number 4", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ReadWriteDialog.WriteFileAs(whatToSave);
                }
                else
                {
                    window.Close();
                }
            }
        }

        /// <summary>
        /// If no file or new document is selected
        /// the textarea is not enabled.
        /// </summary>
        private void EnableEditing()
        {
            if (window.text.IsEnabled == false)
                window.text.IsEnabled = true;
        }
    }
}
