using System;
using Udaiyan.MaxNumberFouledUnits.DataProviders;
using Udaiyan.MaxNumberFouledUnits.StringProviders;
using Udaiyan.MaxNumberFouledUnitsTests.TestRepository;
using Moq;
using NUnit.Framework;

namespace Udaiyan.MaxNumberFouledUnitsTests.UnitTests
{
    [TestFixture]
    public class WaterUnitsFileHandlerTests
    {
        [Test]
        public void WaterUnitsFileHandler_with_null_path_should_throw_ArgumentNullException()
        {
            //Assert
            Assert.That(() => new WaterUnitsFileHandler(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void WaterUnitsFileHandler_with_null_path_should_throw_correct_error_message()
        {
            //Arrange

            //Act
            var ex = Assert.Throws<ArgumentNullException>(() => new WaterUnitsFileHandler(null));

            //Assert
            Assert.That(ex.Message, Is.EqualTo(ErrorStrings.NULL_PATH_FILE + "\r\nParameter name: WaterUnitsFilePath"));
        }

        [Test]
        public void WaterUnitsFileHandler_with_null_CheckWaterUnitsFile_should_throw_ArgumentNullException()
        {
            //Arrange
            var WaterUnitsFileReader = new Mock<IWaterUnitsFileReader>();

            //Assert
            Assert.That(() => new WaterUnitsFileHandler(null, WaterUnitsFileReader.Object), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void WaterUnitsFileHandler_with_null_CheckWaterUnitsFile_should_throw_correct_error_message()
        {
            //Arrange
            var WaterUnitsFileReader = new Mock<IWaterUnitsFileReader>();

            //Act
            var ex = Assert.Throws<ArgumentNullException>(() => new WaterUnitsFileHandler(null, WaterUnitsFileReader.Object));

            //Assert
            Assert.That(ex.Message, Is.EqualTo(ErrorStrings.NULL_OBJECT + "\r\nParameter name: checkWaterUnitsFile"));
        }

        [Test]
        public void WaterUnitsFileHandler_with_null_WaterUnitsFileReader_should_throw_ArgumentNullException()
        {
            //Arrange
            var CheckWaterUnitsFile = new Mock<ICheckWaterUnitsFile>();

            //Assert
            Assert.That(() => new WaterUnitsFileHandler(CheckWaterUnitsFile.Object, null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void WaterUnitsFileHandler_with_null_WaterUnitsFileReader_should_throw_correct_error_message()
        {
            //Arrange
            var CheckWaterUnitsFile = new Mock<ICheckWaterUnitsFile>();

            //Act
            var ex = Assert.Throws<ArgumentNullException>(() => new WaterUnitsFileHandler(CheckWaterUnitsFile.Object,null));

            //Assert
            Assert.That(ex.Message, Is.EqualTo(ErrorStrings.NULL_OBJECT + "\r\nParameter name: WaterUnitsFileReader"));
        }

        [Test]
        public void CheckAndGetWaterUnitsLists_with_WaterUnits_should_return_correct_data()
        {
            //Arrange
            var CheckWaterUnitsFile = new Mock<ICheckWaterUnitsFile>();
            var WaterUnitsFileReader = new Mock<IWaterUnitsFileReader>();
            var testWaterUnitsList = TestData.TestWaterUnitsList();

            CheckWaterUnitsFile.Setup(c => c.DataIsCorrect()).Returns(true);
            WaterUnitsFileReader.Setup(p => p.GetWaterUnitsLists()).Returns(testWaterUnitsList);

            var WaterUnitsFileHandler = new WaterUnitsFileHandler(CheckWaterUnitsFile.Object, WaterUnitsFileReader.Object);

            //Act
            var actualWaterUnitsList = WaterUnitsFileHandler.CheckAndGetWaterUnitsLists();

            //Assert
            Assert.That(actualWaterUnitsList, Is.EqualTo(testWaterUnitsList));
        }
    }
}
