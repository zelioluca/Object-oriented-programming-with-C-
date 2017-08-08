using System;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace exercise_4
{
    class ReadWriteDialog
    {
         
        ReadWrite ReadWrite = new ReadWrite();
      //  public string filename { get { return this.filename;  } set { filename = value; } }
        public string titolo; 
        /// <summary>
        /// Opens FileDialog whose owner is given as parameter,
        /// calls ReadFile from ReadWrite class,
        /// returns text read from file or exception message if something went wrong,
        /// opened file's name is given as an out parameter.
        /// </summary>
        /// <param name="window">owner window, Gets the Window property</param>
        /// <param name="filename">filename</param>
        /// <returns>text read form file or exception message</returns>
        public string ReadFile(MainWindow window, out string  filename)
        {
            string text = null;
            filename = null;
            // for use of OpenFileDialog see https://msdn.microsoft.com/en-us/library/microsoft.win32.openfiledialog(v=vs.110).aspx

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files (*.txt)|*.txt";
            dialog.DefaultExt = ".txt";
            dialog.Title = "Exercise number 4";
            //filename = dialog.FileName;
            dialog.ShowDialog(); 
            filename = System.IO.Path.GetFullPath(dialog.FileName); 
            
            try
            {
               text =  ReadWrite.ReadFile(filename);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Master problem in opening the file");
            }

            return text.ToString();
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
            MainWindow windows = new MainWindow();
            string filename = null;
            // Displays a SaveFileDialog so the user can save the text
            // for use of SaveFileDialog see https://msdn.microsoft.com/en-us/library/microsoft.win32.savefiledialog(v=vs.110).aspx
            try
            {

                SaveFileDialog Save = new SaveFileDialog();
                Save.Filter = "Text files (*.txt)|*.txt";
                Save.Title = "Exercise number 4";
                Save.ShowDialog();
                filename = Save.FileName;
                ReadWrite.WriteFile(filename, whatToSave, false);

                if (Save.CheckFileExists == true)
                {
                    WriteFile(filename, whatToSave, false);
                    
                }
                windows.Title = filename.ToString();
                titolo = filename.ToString(); //this is for title when there is a new file!
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
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
                ReadWrite.WriteFile(filename, whatToSave, append);
            }
            catch (Exception ve)
            {
                MessageBox.Show(ve.ToString(), "Error");
            }
        }

        public ReadWrite ReadWrite1
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}



