using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_4
{
    class TitleGenerator
    {
        private string fileName1 = "adjectives.dat";
        private string fileName2 = "substantives.dat";
        private Dictionary<char, string[]> words1 = new Dictionary<char, string[]>();
        private Dictionary<char, string[]> words2 = new Dictionary<char, string[]>();

        public TitleGenerator()
        {
            try
            {
                words1 = ReadWords(fileName1);
                words2 = ReadWords(fileName2);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private Dictionary<char, string[]> ReadWords(string filename)
        {
            Dictionary<char, string[]> sanat = null;
            try
            {
                //open file for reading
                StreamReader reader = File.OpenText(filename);
                string row = "";
                string[] data;
                sanat = new Dictionary<char, string[]>();
                //read each line until the end is reached 
                while (row != null)
                {
                    row = reader.ReadLine();
                    if (row != null && row.Length > 0)
                    {
                        data = row.Split(',');
                        char key = data[0].ToLower().TrimStart().ElementAt(0);
                        sanat.Add(key, data);
                    }
                }
                //if reader is null this will cause an error
                reader.Close();
            }
            catch (Exception e) //ArgumentException (Dictionary, adding), IOException
            {
                throw new Exception(e.Message);
            }
            return sanat;
        }

        public  string Generate(string name)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbb = new StringBuilder();

            string[] newname = new string[name.Length];
            char[] keys = name.ToCharArray();

            for (int i = 0; i < name.Length; i++)
            {
                char key = keys[i];
                string[] data;
                if ((int)key >= ((int)'a') && (int)key <= ((int)'ö'))
                {

                    if (i < (name.Length - 1))
                    {
                        words1.TryGetValue(key, out data);
                        sbb.Append(Char.ToUpper(key));
                        sbb.Append(" . ");
                    }
                    else
                    {
                        words2.TryGetValue(key, out data);
                        sbb.Append(Char.ToUpper(key));

                        sbb.Append("\n\n");
                    }
                    string s;
                    while (true)
                    {
                        s = data[new Random().Next(data.Count())];
                        if (!newname.Contains(s))
                        {
                            newname[i] = s;
                            break;
                        }
                    }
                    sb.Append(s);
                    sb.Append(" ");
                }
            }
            return sbb.ToString() + sb.ToString();
        }
    }
}
