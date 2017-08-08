using System;
using Microsoft.Win32;
using System.Windows.Documents;
using System.IO;
using System.Windows;

namespace exercise_4
{
    class ReadWriteDialog
    {
        private MainWindow Window { get; set; }
        private ReadWrite ReadWrite = new ReadWrite(); 
        
     /// <summary>
        /// Opens FileDialog whose owner is given as parameter,
        /// calls ReadFile from ReadWrite class,
        /// returns text read from file or exception message if something went wrong,
        /// opened file's name is given as an out parameter.
        /// </summary>
        /// <param name="window">owner window, Gets the Window property</param>
        /// <param name="filename">filename</param>
        /// <returns>text read form file or exception message</returns>
        public string ReadFile(MainWindow window, out string filename)
        {
            string text = null;
            filename = null;
            // for use of OpenFileDialog see https://msdn.microsoft.com/en-us/library/microsoft.win32.openfiledialog(v=vs.110).aspx

            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                dialog.DefaultExt = ".txt";
                dialog.Title = "Exercise number 4";
                if (dialog.ShowDialog() == true)
                {

                    ReadWrite.ReadFile(filename);
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return text;
        }

        /// <summary>
        /// Opens SaveFileDialog and passes filename and text given as parameter to WriteFile in 
        /// ReadWrite class.
        /// Returns the file name or null if something went wrong.
        /// </summary>
        /// <param name="whatToSave"></param>
        /// <returns></returns>
        public string WriteFileAs(string whatToSave)
        {
            string filename = null;
            // Displays a SaveFileDialog so the user can save the text
            // for use of SaveFileDialog see https://msdn.microsoft.com/en-us/library/microsoft.win32.savefiledialog(v=vs.110).aspx

            Window.text.SelectAll();
            SaveFileDialog SaveFile = new SaveFileDialog();
            whatToSave = Window.text.Selection.Text;
            if(SaveFile.CheckFileExists == true)
            {
                WriteFile(filename, whatToSave, true); 
            }

            return filename;
        }

        /// <summary>
        /// Passes the filename and what to save directly to WriteFile in ReadWrite class,
        /// throws exception if something goes wrong.
        /// </summary>
        /// <param name="filename">filename</param>
        /// <param name="whatToSave">text to be saved</param>
        /// <param name="append">true append, false do not append</param>
        public void WriteFile(string filename, string whatToSave, bool append)
        {
            try
            {
                

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}



