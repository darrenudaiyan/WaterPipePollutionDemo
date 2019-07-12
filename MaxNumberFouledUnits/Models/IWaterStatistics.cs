
namespace Udaiyan.MaxNumberFouledUnits.Models
{
    /// <summary>
    /// The IWaterUnitsStatistics interface to the IWaterUnits class.
    /// This is the class that calculates the maximum number WaterUnits.
    /// </summary>
    public interface IWaterStatistics
    {
        /// <summary>
        /// Calculates the maximum number of WaterUnits that can be contaminated
        /// </summary>
        /// <returns>
        /// Integer
        /// </returns>
        /// <remarks>
        /// Loop through the list of lists 
        /// For each list: add the list to a set of currentFouledUnits
        /// Loop through the units in currentFouledUnits
        /// If any unit is first in the list of lists then it has child units downstream of it
        /// so add the child units to the set of currentFouledUnits
        /// keep looping through the units in currentFouledUnits to get all the child units until the set stops growing
        /// Then go to the next list and repeat
        /// If the currentFouledUnits is greater than the number of fouledUnits,
        /// store it as the fouledUnits and return the count of fouledUnits at the end
        /// </remarks>
        int GetMaxNumberOfFouledUnits();
    }
}
