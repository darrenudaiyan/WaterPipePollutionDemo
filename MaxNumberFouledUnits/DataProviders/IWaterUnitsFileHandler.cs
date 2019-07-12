using System.Collections.Generic;

namespace Udaiyan.MaxNumberFouledUnits.DataProviders
{
    /// <summary>
    /// The IWaterUnitsFileHandler interface to the WaterUnitsFileHandler class.
    /// This reads and checks the WaterUnits file and returns a list of lists.
    /// </summary>
    public interface IWaterUnitsFileHandler
    {
        /// <summary>
        /// This uses the WaterUnitsFileReader object to get the WaterUnits lists.
        /// It was done this way to make unit testing easier and reduce the class size.
        /// </summary>
        /// <returns>
        /// A List of Lists
        /// </returns>
        List<List<string>> CheckAndGetWaterUnitsLists();
    }
}
