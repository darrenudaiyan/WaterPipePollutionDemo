using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Udaiyan.MaxNumberFouledUnits.DataProviders;
using Udaiyan.MaxNumberFouledUnits.StringProviders;

namespace Udaiyan.MaxNumberFouledUnits.Models
{
    /// <summary>
    /// This is the class that calculates the maximum number WaterUnits.
    /// </summary>
    public class WaterStatistics : IWaterStatistics
    {
        private readonly IWaterUnitsFileHandler _WaterUnitsFileHandler;

        /// <summary>
        /// Constructor
        /// </summary>
        public WaterStatistics(IWaterUnitsFileHandler WaterUnitsFileHandler)
        {
            CheckMemberVariables(WaterUnitsFileHandler);
            _WaterUnitsFileHandler = WaterUnitsFileHandler;
        }

        /// <summary>
        /// Calculates the maximum number of WaterUnits 
        /// </summary>
        public int GetMaxNumberOfFouledUnits()
        {
            CheckMemberVariables(_WaterUnitsFileHandler);

            var maxNumberOfFouledUnits = 0;
            var fouledUnits = new HashSet<string>();

            //Get the list of WaterUnits lists from the file - a list of lists
            var WaterUnitsLists = _WaterUnitsFileHandler.CheckAndGetWaterUnitsLists();

            // Loop through the list of lists 
            // For each list: add the list to a set of currentFouledUnits
            // Loop through the units in currentFouledUnits
            // If any unit is first in the list of lists then it has child units downstream of it
            // so add the child units to the set of currentFouledUnits
            // keep looping through the units in currentFouledUnits to get all the child units until the set stops growing
            // Then go to the next list and repeat
            // If the currentFouledUnits is greater than the number of fouledUnits,
            // store it as the fouledUnits and return the count of fouledUnits at the end

            foreach (var WaterUnitsList in WaterUnitsLists)
            {
                var currentFouledUnits = new HashSet<string>(WaterUnitsList);
                var currentFouledUnitsCount = currentFouledUnits.Count;
                while (true)
                {
                    currentFouledUnits.UnionWith(GetChildUnits(currentFouledUnits, WaterUnitsLists));
                    if (currentFouledUnits.Count > currentFouledUnitsCount)
                    {
                        currentFouledUnitsCount = currentFouledUnits.Count;
                    }
                    else
                    {
                        break;  //the list of units has stopped growing so break from the loop
                    }
                }

                //Check if the currentFouledUnits set is larger than the fouledUnits set and reassign if it is
                if (currentFouledUnits.Count > fouledUnits.Count)
                {
                    fouledUnits = currentFouledUnits;
                }
            }

            maxNumberOfFouledUnits = fouledUnits.Count;

            return maxNumberOfFouledUnits;
        }

        
        private HashSet<string> GetChildUnits (HashSet<string> currentFouledUnits, List<List<string>> WaterUnitsLists)
        {
            var getChildUnits = new HashSet<string>();

            foreach (var WaterUnitsList in WaterUnitsLists)
            {
                if (currentFouledUnits.Contains(WaterUnitsList.First()))
                {
                    getChildUnits.UnionWith(WaterUnitsList);
                }
            }

            return getChildUnits;
        }

        private void CheckMemberVariables(IWaterUnitsFileHandler WaterUnitsFileHandler)
        {
            if (WaterUnitsFileHandler == null)
            {
                throw new ArgumentNullException(nameof(WaterUnitsFileHandler), ErrorStrings.NULL_FILE_HANDLER);
            }
        }
    }
}
