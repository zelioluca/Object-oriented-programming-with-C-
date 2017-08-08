using System;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace exercise5
{
    class ReadWriteDialog
    {
        public MainWindow window { get; set; }

        ReadWriteCSV ReadWriteCSV = new ReadWriteCSV();
        ReadWrite ReadWrite = new ReadWrite();

        List<string[]> textForGrid = new List<string[]>();
        
        
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

       public List<string[]>OpenReadCSVFile(MainWindow window, out string filename)
        {
           

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV files (*.csv)|*.csv";
            dialog.DefaultExt = ".csv";
            dialog.Title = "Exercise number 5";
            dialog.ShowDialog();
            filename = System.IO.Path.GetFullPath(dialog.FileName);

            try
            {
                textForGrid = ReadWriteCSV.ReadFile(filename);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error in reading the file"); 
            }

            return textForGrid; 
        }
        public string WriteFileAsCSV(List<string[]>data)
        {
            return null; 
        }
        public void WriteFileCSV(string filename, List<string[]>whatToSave, bool p)  // guarda whatto save 
        {
            try
            {

                SaveFileDialog Save = new SaveFileDialog();
                Save.Filter = "Text files (*.txt)|*.txt";
                Save.Title = "Exercise number 4";
                Save.ShowDialog();
                filename = Save.FileName;
                ReadWriteCSV.WriteFile(filename, whatToSave, false);

                if (Save.CheckFileExists == true)
                {
                   ReadWriteCSV.WriteFile(filename, whatToSave, false);

                }
                window.Title = filename.ToString();
                titolo = filename.ToString(); //this is for title when there is a new file!
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                //return null; void -> no return
            }


            //return filename; void -> no return 
        }

       
    }
}



