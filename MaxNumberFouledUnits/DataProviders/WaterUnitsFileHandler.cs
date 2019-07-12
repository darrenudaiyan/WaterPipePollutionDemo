using System;
using System.Collections.Generic;
using Udaiyan.MaxNumberFouledUnits.StringProviders;

namespace Udaiyan.MaxNumberFouledUnits.DataProviders
{
    /// <summary>
    /// This reads and checks the WaterUnits file and returns a list of lists.
    /// </summary>
    public class WaterUnitsFileHandler : IWaterUnitsFileHandler
    {
        private readonly ICheckWaterUnitsFile _checkWaterUnitsFile;
        private readonly IWaterUnitsFileReader _WaterUnitsFileReader;

        /// <summary>
        /// Constructor
        /// </summary>
        public WaterUnitsFileHandler(string WaterUnitsFilePath)
        {
            if (string.IsNullOrEmpty(WaterUnitsFilePath))
            {
                throw new ArgumentNullException(nameof(WaterUnitsFilePath),ErrorStrings.NULL_PATH_FILE);
            }

            _checkWaterUnitsFile = new CheckWaterUnitsFile(WaterUnitsFilePath);
            _WaterUnitsFileReader = new WaterUnitsFileReader(WaterUnitsFilePath);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public WaterUnitsFileHandler(ICheckWaterUnitsFile checkWaterUnitsFile, IWaterUnitsFileReader WaterUnitsFileReader)
        {

            CheckMemberVariables(checkWaterUnitsFile, WaterUnitsFileReader);
            _checkWaterUnitsFile = checkWaterUnitsFile;
            _WaterUnitsFileReader = WaterUnitsFileReader;
        }

        /// <summary>
        /// It was done this way to make unit testing easier and reduce the class size.
        /// </summary>
        public List<List<string>> CheckAndGetWaterUnitsLists()
        {
            CheckMemberVariables(_checkWaterUnitsFile, _WaterUnitsFileReader);

            List<List<string>> WaterUnitsLists = null;

            if (_checkWaterUnitsFile.DataIsCorrect())
            {
                WaterUnitsLists = _WaterUnitsFileReader.GetWaterUnitsLists();
            }
           
            return WaterUnitsLists;
        }

        private void CheckMemberVariables(ICheckWaterUnitsFile checkWaterUnitsFile, IWaterUnitsFileReader WaterUnitsFileReader)
        {
            if (checkWaterUnitsFile == null)
            {
                throw new ArgumentNullException(nameof(checkWaterUnitsFile), ErrorStrings.NULL_OBJECT);
            }

            if (WaterUnitsFileReader == null)
            {
                throw new ArgumentNullException(nameof(WaterUnitsFileReader), ErrorStrings.NULL_OBJECT);
            }
        }
    }
}
