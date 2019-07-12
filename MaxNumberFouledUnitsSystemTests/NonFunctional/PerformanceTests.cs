using System.Runtime.InteropServices.WindowsRuntime;
using Udaiyan.MaxNumberFouledUnits.Models;
using NUnit.Framework;

namespace Udaiyan.MaxNumberFouledUnitsSystemTests.NonFunctional
{
    [TestFixture]
    public class PerformanceTests
    {
        [Test, MaxTime(30000)]
        public void GetMaxNumberOfFouledUnits_with_large_data_set_50_times_should_take_less_than_thirty_seconds()
        {
            for (int i = 0; i <= 50; i++)
            {
                var WaterUnits = new WaterUnits(System.AppContext.BaseDirectory + @"\TestRepository\LargeTestData");
                var maxNumberOfFouledUnits = WaterUnits.GetMaxNumberOfFouledUnits();
            }
        }
    }
}
