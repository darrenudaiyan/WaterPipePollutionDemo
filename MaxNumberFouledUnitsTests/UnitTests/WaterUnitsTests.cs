using System;
using Udaiyan.MaxNumberFouledUnits.DataProviders;
using Udaiyan.MaxNumberFouledUnits.Models;
using Udaiyan.MaxNumberFouledUnits.StringProviders;
using Moq;
using NUnit.Framework;

namespace Udaiyan.MaxNumberFouledUnitsTests.UnitTests
{
    [TestFixture]
    public class WaterUnitsTests
    {
        [Test]
        public void WaterUnits_with_null_path_should_throw_ArgumentNullException()
        {
            //Assert
            Assert.That(() => new WaterUnits(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void WaterUnits_with_null_path_should_throw_correct_error_message()
        {
            //Arrange

            //Act
            var ex = Assert.Throws<ArgumentNullException>(() => new WaterUnits(null));

            //Assert
            Assert.That(ex.Message, Is.EqualTo(ErrorStrings.NULL_PATH_FILE + "\r\nParameter name: WaterUnitsFilePath"));
        }

        [Test]
        public void GetMaxNumberOfFouledUnits_with_real_WaterUnits_should_return_correct_data()
        {
            //Arrange
            var expectedMaxNumberOfFouledUnits = 123;
            var WaterUnitsFileHandler = new Mock<IWaterUnitsFileHandler>();
            var WaterUnitsStatistics = new Mock<IWaterStatistics>();
            WaterUnitsStatistics.Setup(p => p.GetMaxNumberOfFouledUnits()).Returns(expectedMaxNumberOfFouledUnits);

            var WaterUnits = new WaterUnits(WaterUnitsFileHandler.Object, WaterUnitsStatistics.Object);

            //Act
            var actualMaxNumberOfFouledUnits = WaterUnits.GetMaxNumberOfFouledUnits();

            //Assert
            Assert.That(actualMaxNumberOfFouledUnits, Is.EqualTo(expectedMaxNumberOfFouledUnits));
        }
    }
}
