using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace exercise5
{
    /// <summary>
    /// Implements IreadWrite interface so that the file is read as string and 
    /// saved content is given as a string
    /// </summary>
    public class ReadWrite : IReadWrite
    {
       
       
        public MainWindow window { get; set; }
        public string filename { get; set; }
        /// <summary>
        /// Reads given file as text and returns the read text,
        /// thows exception if something goes wrong
        /// </summary>
        /// <param name="filename">name of the file</param>
        /// <returns>text that was read</returns>
        public virtual string ReadFile(string filename)
        {
            StringBuilder contents = new StringBuilder(filename);
            string luca=null;
            string text = "";
            try
            {
                StreamReader reader = new StreamReader(filename);

                
                while((luca = reader.ReadLine()) != null)
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

        /// <summary>
        /// Writes given text to given file, appended or not,
        /// throws exception if something goes wrong
        /// </summary>
        /// <param name="filename">filename</param>
        /// <param name="whatToSave">text to be saved</param>
        /// <param name="append">true = append, false = do not append</param>
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

        //internal void WriteFile(string filename, List<string[]> whatToSave, bool v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
