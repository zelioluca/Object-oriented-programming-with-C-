 using System;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace exercise5 
{
    class ReadWriteDialog
    {
         
        ReadWrite ReadWrite = new ReadWrite();
        ReadWriteCSV ReadWriteCSV = new ReadWriteCSV();
        public MainWindow window { get; set; }
        public string filename { get; set;  }

        public string titolo;

        public List<string[]> textForGrid = new List<string[]>();


        public string ReadFile(MainWindow window, out string  filename)
        {
            string text = null;
            filename = null;
           

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



     
        public string WriteFileAs(string whatToSave)
        {
            MainWindow windows = new MainWindow();
            string filename = null;
           
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
                titolo = filename.ToString(); 
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }


            return filename;
        }

 
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
                textForGrid = ReadWriteCSV.ReadFileCSV(filename) ;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error in reading the file");
            }
            //foreach (var e in textForGrid)
            //{
            //    textForGrid.Add(e);
            //}
            return textForGrid;
        }
        public string WriteFileAsCSV(List<string[]> whatToSave)
        {
            MainWindow window = new MainWindow();
            string filename = null; 
            try
            {

                SaveFileDialog Save = new SaveFileDialog();
                Save.Filter = "Text files (*.csv)|*.csv";
                Save.Title = "Exercise number 5";
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
                return null; 
            }


            return filename; 
        }
        public void WriteFileCSV(string filename, List<string[]> whatToSave, bool p)  // guarda whatto save 
        {
            ReadWriteCSV.WriteFile(filename, whatToSave, false); 
        }

        }

}




