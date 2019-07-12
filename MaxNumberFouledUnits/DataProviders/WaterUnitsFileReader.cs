using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Udaiyan.MaxNumberFouledUnits.StringProviders;
using Udaiyan.MaxNumberFouledUnits.Stubs;

namespace Udaiyan.MaxNumberFouledUnits.DataProviders
{
    /// <summary>
    /// This reads the WaterUnits file and returns a list of lists.
    /// </summary>
    public class WaterUnitsFileReader : IWaterUnitsFileReader
    {
        private readonly string _WaterUnitsFilePath;
        private readonly IFile _file;

        /// <summary>
        /// Constructor
        /// </summary>
        public WaterUnitsFileReader(string WaterUnitsFilePath)
        {
            if (string.IsNullOrEmpty(WaterUnitsFilePath))
            {
                throw new ArgumentNullException(nameof(WaterUnitsFilePath),ErrorStrings.NULL_PATH_FILE);
            }

            _WaterUnitsFilePath = WaterUnitsFilePath;
            _file = new Stubs.File();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public WaterUnitsFileReader(string WaterUnitsFilePath, IFile file)
        {
            if (string.IsNullOrEmpty(WaterUnitsFilePath))
            {
                throw new ArgumentNullException(nameof(WaterUnitsFilePath), ErrorStrings.NULL_PATH_FILE);
            }

            CheckFileStub(file, WaterUnitsFilePath);

            _WaterUnitsFilePath = WaterUnitsFilePath;
            _file = file;
        }

        /// <summary>
        /// This actually reads the file and returns a list of lists of WaterUnits.
        /// </summary>
        public List<List<string>> GetWaterUnitsLists()
        {
            CheckFileStub(_file, _WaterUnitsFilePath);

            var WaterUnitsLists = new List<List<string>>();

            try
            {
                foreach (var line in _file.ReadLines(_WaterUnitsFilePath))
                {
                    var parsedLine = line.Replace(" ", string.Empty).ToLower();
                    var WaterUnits = parsedLine.Split(',');

                    CheckIfDuplicateWaterUnitsNames(WaterUnits);

                    var WaterUnitsList = new List<string>(WaterUnits);
                    WaterUnitsLists.Add(WaterUnitsList);
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return WaterUnitsLists;
        }

        private static void CheckIfDuplicateWaterUnitsNames(string[] WaterUnitsNames)
        {
            if (WaterUnitsNames.Length != WaterUnitsNames.Distinct().Count())
            {
                throw new InvalidOperationException(ErrorStrings.DUPLICATE_WaterUnits + String.Join(",", WaterUnitsNames));
            }
        }

        private void CheckFileStub(IFile file, string WaterUnitsFilePath)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file), ErrorStrings.NULL_FILE);
            }

            if (!file.Exists(WaterUnitsFilePath))
            {
                throw new FileNotFoundException(ErrorStrings.PATH_NOT_FOUND);
            }
        }
    }
}
