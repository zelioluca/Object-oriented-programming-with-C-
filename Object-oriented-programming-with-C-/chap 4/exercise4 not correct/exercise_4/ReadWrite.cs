using System;
using System.IO;
using System.Text;

namespace exercise_4
{
    /// <summary>
    /// Implements IreadWrite interface so that the file is read as string and 
    /// saved content is given as a string
    /// </summary>
    
    public class ReadWrite : IReadWrite
    {
        private MainWindow Window { get; set; }
        /// <summary>
        /// Reads given file as text and returns the read text,
        /// thows exception if something goes wrong
        /// </summary>
        /// <param name="filename">name of the file</param>
        /// <returns>text that was read</returns>
        public virtual string ReadFile(string filename)
        {
            StringBuilder contents = new StringBuilder("");


           

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
                

            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}
