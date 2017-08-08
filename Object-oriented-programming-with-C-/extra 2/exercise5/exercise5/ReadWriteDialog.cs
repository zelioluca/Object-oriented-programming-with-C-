using System;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace exercise5
{
    class ReadWriteDialog
    {

        ReadWrite ReadWrite = new ReadWrite();
        ReadWriteCSV ReadWriteCSV = new ReadWriteCSV();
        ReadWriteMPK ReadWriteMPK = new ReadWriteMPK(); 
        public MainWindow window { get; set; }
        public string filename { get; set; }

        public string titolo;

        public static List<string[]> textForGrid = new List<string[]>();

        public static List<string[]> MPKContent = new List<string[]>(); 


        public string ReadFile(MainWindow window, out string filename)
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
                text = ReadWrite.ReadFile(filename);
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
        public List<string[]> OpenReadCSVFile(MainWindow window, out string filename)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV files (*.csv)|*.csv";
            dialog.DefaultExt = ".csv";
            dialog.Title = "Exercise number 5";
            dialog.ShowDialog();
            filename = System.IO.Path.GetFullPath(dialog.FileName);



            try
            {
                textForGrid = ReadWriteCSV.ReadFileCSV(filename);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error in reading the file");
            }
           
            return textForGrid;
        }
        public string WriteFileAsCSV(ObservableCollection<Lista>Data)
        {
            MainWindow window = new MainWindow();
            string filename = null;
            try
            {

                SaveFileDialog Save = new SaveFileDialog();
                Save.Filter = "CSV files (*.csv)|*.csv";
                Save.Title = "Exercise number 5";
                Save.ShowDialog();
                filename = Save.FileName;
                ReadWriteCSV.WriteThatCvs(filename, Data, false);

                if (Save.CheckFileExists == true)
                {
                    ReadWriteCSV.WriteThatCvs(filename, Data, false);

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

        //-------------------------------------------MPKstory---------------------------------------------------//

        public List<string[]> OpenReadMPKFile(MainWindow window, out string filename)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "MPK files (*.mpk)|*.mpk";
            dialog.DefaultExt = ".csv";
            dialog.Title = "Exercise number Extra 2";
            dialog.ShowDialog();
            filename = System.IO.Path.GetFullPath(dialog.FileName);
            window.Title = filename; 



            try
            {
                MPKContent = ReadWriteMPK.ReadFileCSV(filename);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error in reading the file");
            }
            
            return MPKContent;
        }
        public string WriteFileAsMPK(List<string[]> whatToSave)
        {
            MainWindow window = new MainWindow();
            string filename = null;
            try
            {

                SaveFileDialog Save = new SaveFileDialog();
                Save.Filter = "MPK Files (*.mpk)|*.mpk";
                Save.Title = "Exercise number extra 2";
                Save.ShowDialog();
                filename = Save.FileName;
                ReadWriteMPK.WriteFile(filename, whatToSave, false);

                if (Save.CheckFileExists == true)
                {
                    ReadWriteMPK.WriteFile(filename, whatToSave, false);

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
        public void WriteFileMPK(string filename, List<string[]> whatToSave, bool p)  // guarda whatto save 
        {
            ReadWriteMPK.WriteFile(filename, whatToSave, false);
        }

    }
}




