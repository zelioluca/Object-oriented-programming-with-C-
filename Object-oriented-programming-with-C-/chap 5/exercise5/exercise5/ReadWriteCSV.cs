using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace exercise5
{
   public class ReadWriteCSV 
    {
        public MainWindow window { get; set; }
        static string[] data;
        public  List<string[]> ReadFileCSV(string filename)
        {


            List<string[]> content = new List<string[]>();
            string row = " ";
            try
            {
                StreamReader reader = File.OpenText(filename);

                while (row != null)
                {

                    row = reader.ReadLine();
                    if (row != null && row.Length > 0)
                    {
                        data = row.Split(';');
                        content.Add(data);
                    }
                }
                reader.Close();

                return content;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return content;   //try to improve
        }

        public void WriteFile(string filename, List<string[]> whatToSave, bool append)  //whattosave? 
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
                             //if (count++ < v.Length)
                                sb.Append(",");
                           
                        }
                    }
                    sb.AppendLine();
                   
                }
                file.WriteLine(sb.ToString());
                

            }
        }
    }

}
