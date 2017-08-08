using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace exercise5
{
    class ReadWriteMPK: ReadWriteCSV
    {
        ReadWrite ReadWrite = new ReadWrite();

        ReadWriteCSV ReadWriteCSV = new ReadWriteCSV();
       

        string text;
        public static List<string[]> textForGrid { get; set; }

        public new MainWindow window { get; set;  } 
        public override List<string[]> ReadFileCSV(string filename)
        {
            return base.ReadFileCSV(filename);
        }

        public new virtual void WriteFile(string filename, List<string[]> whatToSave, bool append) 
        {
            StreamWriter file = new StreamWriter(filename, append);
            using (file)
            {


                StringBuilder sb = new StringBuilder();
                foreach (var v in whatToSave)
                {
                    //  count = 0;
                    foreach (var vv in v)
                    {
                        if (vv.Length > 0)
                        {
                            sb.Append(vv);
                            

                        }
                    }
                    sb.AppendLine();

                }
                file.WriteLine(sb.ToString());


            }

        }

        public void SplitThisFile(List<string[]> MPKcontent, MainWindow window)
        {
            string textFormat;
            string csvFormat;
          
                if (MPKcontent[0][0].Contains("luca.txt"))  
                {
                    textFormat = Path.GetFullPath(MPKcontent[0][0].ToString());
                window.Ptxt.Text = textFormat; 
                    text = ReadWrite.ReadFile(textFormat);
                    window.text.Document.Blocks.Clear(); 
                    window.text.AppendText(text);
                }
                if (MPKcontent[1][0].Contains("luca.csv"))
                {
                    csvFormat   = Path.GetFullPath(MPKcontent[1][0].ToString());
                window.PCsv.Text = csvFormat; 
                    textForGrid =  ReadWriteCSV.ReadFileCSV(csvFormat);
                    window.InitializeDatagrid();
                    
                }
                else
                {
                    MessageBox.Show("Something goes wrong, check the code", "Extra 2");
                }

        
        }
        
       }
     }
    

