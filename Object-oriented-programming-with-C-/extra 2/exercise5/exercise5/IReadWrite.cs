using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise5
{
    interface IReadWrite
    {
        
        string ReadFile(string filename);
        void WriteFile(string filename, string whatToSave, bool append);
        void WriteFile(string filename, List<string[]> whatToSave, bool append);
        List<string[]> OpenReadCSVFile(MainWindow window, out string filename);
    }
}
