using System.Collections.Generic;

namespace Udaiyan.MaxNumberFouledUnits.DataProviders
{
    /// <summary>
    /// The IWaterUnitsFileReader interface to the WaterUnitsFileReader class.
    /// This reads the WaterUnits file and returns a list of lists.
    /// It was separated from the handler class to make it easier to test the results returned
    /// and also to reduce the class size.
    /// </summary>
    public interface IWaterUnitsFileReader
    {
        /// <summary>
        /// This actually reads the file and returns a list of lists of WaterUnits.
        /// </summary>
        /// <returns>
        /// A List of Lists
        /// </returns>
        List<List<string>> GetWaterUnitsLists();
    }
}
