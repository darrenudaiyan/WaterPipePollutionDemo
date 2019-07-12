using Udaiyan.MaxNumberFouledUnits.Models;
using NUnit.Framework;

namespace Udaiyan.MaxNumberFouledUnitsSystemTests.NonFunctional
{
    [TestFixture]
    public class LanguageTests
    {

        [TestCaseSource("LanguageTestCases")]
        public void GetMaxNumberOfFouledUnits_with_real_WaterUnits_in_different_languages_should_return_correct_data(string languageTestCase, int expectedMaxNumberOfFouledUnits)
        {
            //Arrange
            var WaterUnits = new WaterUnits(System.AppContext.BaseDirectory + @"\TestRepository\" + languageTestCase);

            //Act
            var maxNumberOfFouledUnits = WaterUnits.GetMaxNumberOfFouledUnits();

            //Assert
            Assert.That(maxNumberOfFouledUnits, Is.EqualTo(expectedMaxNumberOfFouledUnits));
        }

        static object[] LanguageTestCases =
        {
            new object[] {"InterviewTestData", 7  },
            new object[] { "InterviewTestDataChinese",7 },
            new object[] { "InterviewTestDataHindi", 7 }
        };
    }
}
