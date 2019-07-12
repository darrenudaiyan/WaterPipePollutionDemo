
namespace Udaiyan.MaxNumberFouledUnits.Models
{
    /// <summary>
    /// The IWaterUnits interface to the WaterUnits class.
    /// This is the main class to get the GetMaxNumberOfFouledUnits.
    /// </summary>
    public interface IWaterUnits
    {
        /// <summary>
        /// Uses the WaterStatistics object to calculate the MaxNumberOfFouledUnits
        /// </summary>
        int GetMaxNumberOfFouledUnits();
    }
}
