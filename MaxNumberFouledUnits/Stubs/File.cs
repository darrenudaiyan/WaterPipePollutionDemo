using System.Collections.Generic;

namespace Udaiyan.MaxNumberFouledUnits.Stubs
{
    /// <summary>
    /// File Stub 
    /// </summary>
    public class File : IFile
    {
        /// <summary>
        /// File Exists 
        /// </summary>
        public bool Exists(string fileName) => System.IO.File.Exists(fileName);

        /// <summary>
        /// File ReadAllText 
        /// </summary>
        public string ReadAllText(string path) => System.IO.File.ReadAllText(path);

        /// <summary>
        /// File ReadLines 
        /// </summary>
        public IEnumerable<string> ReadLines(string path)
        {
            return System.IO.File.ReadLines(path);
        }
    }
}
