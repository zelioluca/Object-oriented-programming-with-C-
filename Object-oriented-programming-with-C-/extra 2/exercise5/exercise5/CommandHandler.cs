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
using System.Windows.Controls;

namespace exercise5
{
    /// <summary>
    /// Actually handles the commands passed from MainWindow
    /// </summary>
    class CommandHandler
    {
        private string defaultfileName = "noname.txt";
        private string fileName;
        public static string save { get; set; } 

        ReadWriteDialog ReadWriteDialog = new ReadWriteDialog();
        ReadWrite ReadWrite = new ReadWrite();
        ReadWriteCSV ReadWriteCSV = new ReadWriteCSV();
        ReadWriteMPK ReadWriteMPK = new ReadWriteMPK();

       


        public MainWindow window { get; set; }
        
        //public string text { get; set; }
        //public string whatToSave { get; set; }

        public List<string[]> textForGrid { get { return ReadWriteMPK.textForGrid; } }
       
        public List<Lista>MasterList { get; set; }

        public List<string[]> whatToSave { get; set;  }
        public static List<string[]> MPKContent { get; set; }

        public string text { get; set; }

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

                //textForGrid =  ReadWriteDialog.OpenReadCSVFile(window, out fileName);
                //data.gridFill(window, textForGrid);
                //window.Title = fileName;
                MPKContent = ReadWriteDialog.OpenReadMPKFile(window, out fileName);

                window.txtBlock.Text = MPKContent[0][0].ToString();
                window.csvBlock.Text = MPKContent[1][0].ToString();

                ReadWriteMPK.SplitThisFile(MPKContent, window); 

                

            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }

        }

        
        public void Save(bool isname)
        {
            window.text.SelectAll();
            save = window.text.Selection.Text;
            whatToSave = textForGrid;         //null
            fileName = window.Title;
            if(isname == true)
            {
                if(fileName == defaultfileName)
                {

                    ReadWriteDialog.WriteFileAsCSV(window.Data);
                    ReadWriteDialog.WriteFileAs(save);
                    
                    if(fileName !=null)
                    {

                        window.Title = ReadWriteDialog.titolo.ToString() ; 
                    }

                }  ///////////////// heere 
                else
                {
                    //fileName = ReadWriteDialog.filename.ToString();
                   
                    ReadWriteDialog.WriteFileAsCSV(window.Data); //
                    //ReadWriteDialog.WriteFile(fileName, save, false); 
                    ReadWriteDialog.WriteFileAs(save);
                }
            }
            else
            {
                ReadWriteDialog.WriteFileAsMPK(MPKContent);
                window.Title = fileName;
               // ReadWriteDialog.WriteFileAsCSV(whatToSave);
                //ReadWriteDialog.WriteFileAs(save);
            }


        }
        //public void Close()
        //{
        //    Environment.Exit(0);
        //}

        public bool Close()
        {


            List<string[]> text = new List<string[]>();
            text = ReadWriteCSV.ReadFileCSV(window.Title);
            bool re = false;
            //nothing to save
            if (window.dataGrid1.IsEnabled == false || whatToSave.Count == 0) //|| whatToSave.Count == text.Count)
            {
                Environment.Exit(0);
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to save?", "Exercise number 4", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (window.Title == defaultfileName)
                        ReadWriteDialog.WriteFileAsCSV(window.Data);
                    else
                        ReadWriteDialog.WriteFileCSV(fileName, whatToSave, false);
                }
                else if (result == DialogResult.No)
                {
                    Environment.Exit(0);
                }
                else
                {
                    return re = true;
                }
            }
            return re = false;
        }


        private void EnableEditing()
        {
            if (window.dataGrid1.IsEnabled == false)
                window.dataGrid1.IsEnabled = true;
        }
    }

    
}
