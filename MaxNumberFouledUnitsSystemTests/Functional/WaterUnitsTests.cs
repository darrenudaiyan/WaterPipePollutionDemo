using System.IO;
using Udaiyan.MaxNumberFouledUnits.Models;
using Udaiyan.MaxNumberFouledUnits.StringProviders;
using NUnit.Framework;

namespace Udaiyan.MaxNumberFouledUnitsSystemTests.Functional
{
    [TestFixture]
    public class WaterUnitsTests
    {
        [Test]
        public void GetMaxNumberOfFouledUnits_with_real_WaterUnits_should_return_correct_data()
        {
            //Arrange
            var expectedMaxNumberOfFouledUnits = 7;
            var WaterUnits = new WaterUnits(System.AppContext.BaseDirectory + @"\TestRepository\InterviewTestData");           

            //Act
            var maxNumberOfFouledUnits = WaterUnits.GetMaxNumberOfFouledUnits();

            //Assert
            Assert.That(maxNumberOfFouledUnits, Is.EqualTo(expectedMaxNumberOfFouledUnits));
        }

        [Test]
        public void GetMaxNumberOfFouledUnits_with_invalid_data_should_throw_InvalidDataException()
        {
            //Arrange
            var WaterUnits = new WaterUnits(System.AppContext.BaseDirectory + @"\TestRepository\BadTestData");

            //Act
            
            //Assert
            Assert.That(() => WaterUnits.GetMaxNumberOfFouledUnits(), Throws.Exception.TypeOf<InvalidDataException>());
        }

        [Test]
        public void GetMaxNumberOfFouledUnits_with_invalid_data_should_throw_correct_error_message()
        {
            //Arrange
            var WaterUnits = new WaterUnits(System.AppContext.BaseDirectory + @"\TestRepository\BadTestData");

            //Act
            var ex = Assert.Throws<InvalidDataException>(() => WaterUnits.GetMaxNumberOfFouledUnits());

            //Assert
            Assert.That(ex.Message, Is.EqualTo(ErrorStrings.NOT_CSV_FORMAT));
        }

        [TestCaseSource("TestCases")]
        public void GetMaxNumberOfFouledUnits_with_real_data_should_return_correct_type(string testCases)
        {
            //Arrange
            var WaterUnits = new WaterUnits(System.AppContext.BaseDirectory + @"\TestRepository\" + testCases);

            //Act
            var maxNumberOfFouledUnits = WaterUnits.GetMaxNumberOfFouledUnits();

            //Assert
            Assert.That(maxNumberOfFouledUnits, Is.GreaterThanOrEqualTo(0));
        }

        static object[] TestCases =
        {
            new object[] {"TestData1"  },
            new object[] { "TestData2" },
            new object[] { "TestData3" },
            new object[] { "TestData4" }
        };
    }
}
