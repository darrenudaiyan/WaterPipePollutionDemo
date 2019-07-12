using System.Collections.Generic;

namespace Udaiyan.MaxNumberFouledUnits.Stubs
{
    /// <summary>
    /// File Stub 
    /// </summary>
    public interface IFile
    {
        /// <summary>
        /// File Exists 
        /// </summary>
        bool Exists(string fileName);

        /// <summary>
        /// File ReadAllText 
        /// </summary>
        string ReadAllText(string path);

        /// <summary>
        /// File ReadLines 
        /// </summary>
        IEnumerable<string> ReadLines(string path);
    }
}
