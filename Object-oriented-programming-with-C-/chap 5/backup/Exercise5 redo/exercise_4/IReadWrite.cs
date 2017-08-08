
using System.Collections.Generic;

namespace exercise5
{
    /// <summary>
    /// common behavior for classes that perform IO operations
    /// </summary>
    interface IReadWrite
    {
        string ReadFile(string filename);
        void WriteFile(string filename, string whatToSave, bool append);

        

    }
}
