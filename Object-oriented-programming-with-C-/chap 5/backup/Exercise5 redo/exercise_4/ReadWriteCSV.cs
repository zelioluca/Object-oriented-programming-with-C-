using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace exercise5
{
    class ReadWriteCSV: ReadWrite
    {
        static string [] data; 
        public new List<string[]>ReadFile(string filename)
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
            catch (Exception luca)
            {
                MessageBox.Show(luca.ToString());
            }
            return content;   //try to improve
        }

        public new void WriteFile(string filename, List<string[]>whatToSave, bool append)  //whattosave? 
        {
            StreamWriter file = new StreamWriter(filename, append);
            using (file)
            {
                int count = 0;
                StringBuilder sb = new StringBuilder();
                foreach(var v in whatToSave)
                {
                    foreach(var vv in v)
                    {
                        if(vv.Length >0)
                        {
                            sb.Append(vv);
                            if (count++ < v.Length)
                                sb.Append(",");
                        }
                        sb.AppendLine();
                    }
                    file.WriteLine(sb.ToString());
                }
            }
        }
    }
}
