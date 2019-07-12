using System;
using Udaiyan.MaxNumberFouledUnits.DataProviders;
using Udaiyan.MaxNumberFouledUnits.Models;
using Udaiyan.MaxNumberFouledUnits.StringProviders;
using Udaiyan.MaxNumberFouledUnitsTests.TestRepository;
using Moq;
using NUnit.Framework;

namespace Udaiyan.MaxNumberFouledUnitsTests.UnitTests
{
    [TestFixture]
    public class WaterStatisticsTests
    {
        [Test]
        public void WaterUnitsStatistics_with_null_path_should_throw_ArgumentNullException()
        {
            //Assert
            Assert.That(() => new WaterStatistics(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void WaterUnitsStatistics_with_null_path_should_throw_correct_error_message()
        {
            //Arrange

            //Act
            var ex = Assert.Throws<ArgumentNullException>(() => new WaterStatistics(null));

            //Assert
            Assert.That(ex.Message, Is.EqualTo(ErrorStrings.NULL_FILE_HANDLER + "\r\nParameter name: WaterUnitsFileHandler"));
        }

        [Test]
        public void GetMaxNumberOfFouledUnits_with_real_WaterUnits_should_return_correct_data()
        {
            //Arrange
            var testRealWaterUnitsList = TestData.TestRealWaterUnitsList();
            var expectedMaxNumberOfFouledUnits = 7;

            var WaterUnitsFileHandler = new Mock<IWaterUnitsFileHandler>();
            WaterUnitsFileHandler.Setup(p => p.CheckAndGetWaterUnitsLists()).Returns(testRealWaterUnitsList);

            var WaterUnitsStatistics = new WaterStatistics(WaterUnitsFileHandler.Object);

            //Act
            var actualMaxNumberOfFouledUnits = WaterUnitsStatistics.GetMaxNumberOfFouledUnits();

            //Assert
            Assert.That(actualMaxNumberOfFouledUnits, Is.EqualTo(expectedMaxNumberOfFouledUnits));
        }

        [Test]
        public void GetMaxNumberOfFouledUnits_with_distinct_WaterUnits_should_return_correct_data()
        {
            //Arrange
            var testRealWaterUnitsList = TestData.DistinctWaterUnitsList();
            var expectedMaxNumberOfFouledUnits = 2;

            var WaterUnitsFileHandler = new Mock<IWaterUnitsFileHandler>();
            WaterUnitsFileHandler.Setup(p => p.CheckAndGetWaterUnitsLists()).Returns(testRealWaterUnitsList);

            var WaterUnitsStatistics = new WaterStatistics(WaterUnitsFileHandler.Object);

            //Act
            var actualMaxNumberOfFouledUnits = WaterUnitsStatistics.GetMaxNumberOfFouledUnits();

            //Assert
            Assert.That(actualMaxNumberOfFouledUnits, Is.EqualTo(expectedMaxNumberOfFouledUnits));
        }

        [Test]
        public void GetMaxNumberOfFouledUnits_with_joined_WaterUnits_should_return_correct_data()
        {
            //Arrange
            var testRealWaterUnitsList = TestData.JoinedWaterUnitsList();
            var expectedMaxNumberOfFouledUnits = 4;

            var WaterUnitsFileHandler = new Mock<IWaterUnitsFileHandler>();
            WaterUnitsFileHandler.Setup(p => p.CheckAndGetWaterUnitsLists()).Returns(testRealWaterUnitsList);

            var WaterUnitsStatistics = new WaterStatistics(WaterUnitsFileHandler.Object);

            //Act
            var actualMaxNumberOfFouledUnits = WaterUnitsStatistics.GetMaxNumberOfFouledUnits();

            //Assert
            Assert.That(actualMaxNumberOfFouledUnits, Is.EqualTo(expectedMaxNumberOfFouledUnits));
        }
    }
}
