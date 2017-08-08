using System;
using System.IO;
using System.Text;
using System.Windows;

namespace exercise_4
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

            try
            {
                StreamReader reader = new StreamReader(filename);

                string luca;
                while((luca = reader.ReadLine()) != null)
                {
                    contents.AppendLine(luca); 
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Master we have a problem in getting the content of the file");
            }




            //type change (casting) from StringBuilder to string
         
            return contents.ToString();
            
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
                StreamWriter writer = new StreamWriter(filename, true);
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
