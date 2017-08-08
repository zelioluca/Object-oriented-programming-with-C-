using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;

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

        public MainWindow MainWindow
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        internal ReadWriteDialog ReadWriteDialog1
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }





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
            EnableEditing();
            //string contents;
            try
            {
               text= ReadWriteDialog.ReadFile(window, out fileName);

                window.text.AppendText(text);
                window.Title = fileName; 
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
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
            whatToSave = window.text.Selection.Text;
            fileName = window.Title;
            if(isname == true)
            {
                if(fileName == defaultfileName)
                {
                    ReadWriteDialog.WriteFileAs(whatToSave);
                    
                    if(fileName !=null)
                    {

                        window.Title = ReadWriteDialog.titolo.ToString() ; 
                    }

                }  ///////////////// heere 
                else
                {
                   // fileName = ReadWriteDialog.filename.ToString();

                    ReadWriteDialog.WriteFile(fileName, whatToSave, false);
                }
            }
            else
            {
                ReadWriteDialog.WriteFileAs(whatToSave);
            }


        }

        /// <summary>
        /// Closes the window given a a property,
        /// asks if the text in textarea should be saved before closing,
        /// if the file already has a name WriteFile is called, if not WriteFileAs is called in 
        /// ReadWriteDialog class.
        /// </summary>
        public bool Close()
        {
            window.text.SelectAll();
            string whatToSave = window.text.Selection.Text;
            ReadWrite readWrite = new ReadWrite();
            string text = readWrite.ReadFile(window.Title);
            bool re = false;
            //nothing to save
            if (window.text.IsEnabled == false || whatToSave.Length == 0 || whatToSave == text+"\r\n")
            {
                Environment.Exit(0);
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to save?", "Exercise number 4", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if(window.Title == defaultfileName)
                        ReadWriteDialog.WriteFileAs(whatToSave);
                    else
                        ReadWriteDialog.WriteFile(fileName, whatToSave, false);
                }
                else if (result == DialogResult.No)
                {
                    Environment.Exit(0);
                }
                else
                {
                    return re=true;
                }
            }
            return re = false;
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
