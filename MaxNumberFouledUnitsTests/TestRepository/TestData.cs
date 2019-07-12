using System.Collections.Generic;

namespace Udaiyan.MaxNumberFouledUnitsTests.TestRepository
{
    public static class TestData
    {
        public static List<List<string>> TestWaterUnitsList()
        {
            var testWaterUnitsList = new List<List<string>>
            {
                new List<string> {"a", "b"},
                new List<string> {"b", "c"}
            };

            return testWaterUnitsList;
        }

        public static List<List<string>> TestRealWaterUnitsList()
        {
            var testWaterUnitsList = new List<List<string>>
            {
                new List<string> { "Pipe1", "Tank1", "KH1"},
                new List<string> { "Tank1", "COKE1", "VBR1"},
                new List<string> { "Pipe2", "Tank2", "KH2"},
                new List<string> { "KH3", "VH3"},
                new List<string> { "Pipe3", "Tank3","KH5"},
                new List<string> { "KH3", "VH3"},
                new List<string> { "KH1", "NH1"},
                new List<string> { "NH1", "CC1"},
            };

            return testWaterUnitsList;
        }

        public static List<List<string>> DistinctWaterUnitsList()
        {
            var testWaterUnitsList = new List<List<string>>
            {
                new List<string> {"a", "b"},
                new List<string> {"b", "a"},
                new List<string> {"c", "d"},
                new List<string> {"d", "c"}
            };

            return testWaterUnitsList;
        }

        public static List<List<string>> JoinedWaterUnitsList()
        {
            var testWaterUnitsList = new List<List<string>>
            {
                new List<string> {"a", "b"},
                new List<string> {"b", "c"},
                new List<string> {"c", "d"},
            };

            return testWaterUnitsList;
        }

    }
}
