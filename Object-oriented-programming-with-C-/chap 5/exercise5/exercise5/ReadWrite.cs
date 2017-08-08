using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace exercise5
{
    class ReadWrite: ReadWriteCSV
    {
        public MainWindow window { get; set; }
        public string filename { get; set; }
      
        public virtual string ReadFile(string filename)
        {
            StringBuilder contents = new StringBuilder(filename);
            string luca = null;
            string text = "";
            try
            {
                StreamReader reader = new StreamReader(filename);


                while ((luca = reader.ReadLine()) != null)
                {
                    //contents.AppendLine(luca);
                    text = luca;
                }
                //return text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Master we have a problem in getting the content of the file");
            }




            //type change (casting) from StringBuilder to string

            return text;
            //return contents.ToString();
        }

     
        public virtual void WriteFile(string filename, string whatToSave, bool append)
        {
            try
            {
                StreamWriter writer = new StreamWriter(filename, append);
                writer.Write(whatToSave);
                writer.Close();

            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}

