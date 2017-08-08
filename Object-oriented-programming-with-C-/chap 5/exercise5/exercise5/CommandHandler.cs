using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;
using System.Collections.ObjectModel;
using exercise5; 


namespace exercise5
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
        ReadWriteCSV ReadWriteCSV = new ReadWriteCSV();
        Data data = new Data();
        public MainWindow window { get; set; }
        
        //public string text { get; set; }
        //public string whatToSave { get; set; }

        public List<string[]> textForGrid { get; set; }
        public List<List>MasterList { get; set; }
        public static List<string[]> whatToSave { get; set; }

        public void New()
        {
            EnableEditing();
            fileName = defaultfileName;
            window.Title = fileName;
            
        }


        public void Open()
        {
          
            EnableEditing();
           
            try
            {
                
              textForGrid =  ReadWriteDialog.OpenReadCSVFile(window, out fileName);
              data.gridFill(window, textForGrid);
              window.Title = fileName;
          


            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }

        }

        
        public void Save(bool isname)
        {
            //window.text.SelectAll();
            whatToSave = textForGrid; 
            fileName = window.Title;
            if(isname == true)
            {
                if(fileName == defaultfileName)
                {
                    ReadWriteDialog.WriteFileAsCSV(whatToSave);
                    
                    if(fileName !=null)
                    {

                        window.Title = ReadWriteDialog.titolo.ToString() ; 
                    }

                }  ///////////////// heere 
                else
                {
                   // fileName = ReadWriteDialog.filename.ToString();

                    ReadWriteDialog.WriteFileCSV(fileName, whatToSave, false);
                }
            }
            else
            {
                ReadWriteDialog.WriteFileAsCSV(whatToSave);
            }


        }
        public void Close()
        {
            Environment.Exit(0);
        }

        //public bool Close()
        //{


        //    List<string[]> text = new List<string[]>();
        //    text = ReadWriteCSV.ReadFileCSV(window.Title);
        //    bool re = false;
        //    //nothing to save
        //    if (window.dataGrid1.IsEnabled == false || whatToSave.Count == 0) //|| whatToSave.Count == text.Count)
        //    {
        //        Environment.Exit(0);
        //    }
        //    else
        //    {
        //        DialogResult result = MessageBox.Show("Do you want to save?", "Exercise number 4", MessageBoxButtons.YesNoCancel);
        //        if (result == DialogResult.Yes)
        //        {
        //            if (window.Title == defaultfileName)
        //                ReadWriteDialog.WriteFileAsCSV(whatToSave);
        //            else
        //                ReadWriteDialog.WriteFileCSV(fileName, whatToSave, false);
        //        }
        //        else if (result == DialogResult.No)
        //        {
        //            Environment.Exit(0);
        //        }
        //        else
        //        {
        //            return re = true;
        //        }
        //    }
        //    return re = false;
        //}


        private void EnableEditing()
        {
            if (window.dataGrid1.IsEnabled == false)
                window.dataGrid1.IsEnabled = true;
        }
    }

    
}
