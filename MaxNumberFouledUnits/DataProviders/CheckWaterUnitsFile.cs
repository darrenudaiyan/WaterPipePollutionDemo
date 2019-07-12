using System;
using System.IO;
using Udaiyan.MaxNumberFouledUnits.StringProviders;
using Udaiyan.MaxNumberFouledUnits.Stubs;

namespace Udaiyan.MaxNumberFouledUnits.DataProviders
{
    /// <summary>
    /// CheckWaterUnitsFile class: contains all methods to check that the file is correct and a CSV.
    /// </summary>
    public class CheckWaterUnitsFile : ICheckWaterUnitsFile
    {
        private readonly string _WaterUnitsFilePath;
        private readonly IFile _file;

        /// <summary>
        /// Constructor for CheckWaterUnitsFile class.
        /// </summary>
        public CheckWaterUnitsFile(string WaterUnitsFilePath)
        {
            if (string.IsNullOrEmpty(WaterUnitsFilePath))
            {
                throw new ArgumentNullException(nameof(WaterUnitsFilePath),ErrorStrings.NULL_PATH_FILE);
            }

            _WaterUnitsFilePath = WaterUnitsFilePath;
            _file = new Stubs.File();
        }

        /// <summary>
        /// Constructor for CheckWaterUnitsFile class.
        /// </summary>
        public CheckWaterUnitsFile(string WaterUnitsFilePath, IFile file)
        {
            if (string.IsNullOrEmpty(WaterUnitsFilePath))
            {
                throw new ArgumentNullException(nameof(WaterUnitsFilePath), ErrorStrings.NULL_PATH_FILE);
            }

            if (file == null)
            {
                throw new ArgumentNullException(nameof(file), ErrorStrings.NULL_FILE);
            }

            _WaterUnitsFilePath = WaterUnitsFilePath;
            _file = file;
        }

        /// <summary>
        /// Checks if the file exists and if it is a CSV file.
        /// </summary>
        public bool DataIsCorrect()
        {
            if (_file == null)
            {
                throw new ArgumentNullException("file", ErrorStrings.NULL_FILE);
            }

            CheckFileExists();
            CheckFileIsCorrect();
            return true;
        }

        private void CheckFileExists()
        {
            if (!_file.Exists(_WaterUnitsFilePath))
            {
                throw new FileNotFoundException(ErrorStrings.PATH_NOT_FOUND);
            }
        }
        
        //TODO: Need a proper CSV validation method.
        private void CheckFileIsCorrect()
        {
            string fileContent = _file.ReadAllText(_WaterUnitsFilePath);

            if (!fileContent.Contains(","))
            {
                throw new InvalidDataException(ErrorStrings.NOT_CSV_FORMAT);
            }
        }
    }
}
