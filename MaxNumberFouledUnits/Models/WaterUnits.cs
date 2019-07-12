using System;
using Udaiyan.MaxNumberFouledUnits.DataProviders;
using Udaiyan.MaxNumberFouledUnits.StringProviders;


namespace Udaiyan.MaxNumberFouledUnits.Models
{
    /// <summary>
    /// This is the main class to get the MaxNumberOfFouledUnits.
    /// </summary>
    public class WaterUnits : IWaterUnits
    {
        private readonly IWaterUnitsFileHandler _WaterUnitsFileHandler;
        private readonly IWaterStatistics _WaterUnitsStatistics;

        /// <summary>
        /// Constructor
        /// </summary>
        public WaterUnits(string WaterUnitsFilePath)
        {
            if (string.IsNullOrEmpty(WaterUnitsFilePath))
            {
                throw new ArgumentNullException(nameof(WaterUnitsFilePath),ErrorStrings.NULL_PATH_FILE);
            }

            _WaterUnitsFileHandler = new WaterUnitsFileHandler(WaterUnitsFilePath);
            _WaterUnitsStatistics = new WaterStatistics(_WaterUnitsFileHandler);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public WaterUnits(IWaterUnitsFileHandler WaterUnitsFileHandler, IWaterStatistics WaterUnitsStatistics)
        {
            CheckMemberVariables(WaterUnitsFileHandler, WaterUnitsStatistics);
            _WaterUnitsFileHandler = WaterUnitsFileHandler;
            _WaterUnitsStatistics = WaterUnitsStatistics;
        }

        /// <summary>
        /// Uses the WaterUnitstatistics object to calculate the MaxNumberOfFouledUnits
        /// </summary>
        public int GetMaxNumberOfFouledUnits()
        {
            CheckMemberVariables(_WaterUnitsFileHandler, _WaterUnitsStatistics);
            return _WaterUnitsStatistics.GetMaxNumberOfFouledUnits();
        }

        private void CheckMemberVariables(IWaterUnitsFileHandler WaterUnitsFileHandler, IWaterStatistics WaterUnitsStatistics)
        {
            if (WaterUnitsFileHandler == null)
            {
                throw new ArgumentNullException(nameof(WaterUnitsFileHandler), ErrorStrings.NULL_OBJECT);
            }

            if (WaterUnitsStatistics == null)
            {
                throw new ArgumentNullException(nameof(WaterUnitsStatistics), ErrorStrings.NULL_OBJECT);
            }
        }
    }
}
