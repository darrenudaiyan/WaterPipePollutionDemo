
namespace Udaiyan.MaxNumberFouledUnits.DataProviders
{
    /// <summary>
    /// The ICheckWaterUnitsFile interface to the CheckWaterUnitsFile class.
    /// Contains all methods to check that the file is correct and a CSV.
    /// </summary>
    public interface ICheckWaterUnitsFile
    {
        /// <summary>
        /// Checks if the file exists and if it is a CSV file.
        /// TODO: Need a proper CSV parser
        /// </summary>
        bool DataIsCorrect();
    }
}
