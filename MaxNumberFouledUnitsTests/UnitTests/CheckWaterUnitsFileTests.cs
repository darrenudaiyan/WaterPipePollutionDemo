using System;
using System.IO;
using Udaiyan.MaxNumberFouledUnits.DataProviders;
using Udaiyan.MaxNumberFouledUnits.StringProviders;
using Udaiyan.MaxNumberFouledUnits.Stubs;
using Moq;
using NUnit.Framework;

namespace Udaiyan.MaxNumberFouledUnitsTests.UnitTests
{
    [TestFixture]
    public class CheckWaterUnitsFileTests
    {
      
        [Test]
        public void CheckWaterUnitsFile_with_null_path_should_throw_ArgumentNullException()
        {
            //Assert
            Assert.That(() => new CheckWaterUnitsFile(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void CheckWaterUnitsFile_with_null_path_should_throw_correct_error_message()
        {
            //Arrange

            //Act
            var ex = Assert.Throws<ArgumentNullException>(() => new CheckWaterUnitsFile(null));

            //Assert
            Assert.That(ex.Message, Is.EqualTo(ErrorStrings.NULL_PATH_FILE + "\r\nParameter name: WaterUnitsFilePath"));
        }

        [Test]
        public void CheckWaterUnitsFile_with_null_file_should_throw_ArgumentNullException()
        {
            //Assert
            Assert.That(() => new CheckWaterUnitsFile("TestPath", null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void CheckWaterUnitsFile_with_null_file_should_throw_correct_error_message()
        {
            //Arrange

            //Act
            var ex = Assert.Throws<ArgumentNullException>(() => new CheckWaterUnitsFile("TestPath",null));

            //Assert
            Assert.That(ex.Message, Is.EqualTo(ErrorStrings.NULL_FILE + "\r\nParameter name: file"));
        }

        [Test]
        public void DataIsCorrect_with_file_not_existing_should_throw_FileNotFoundException()
        {
            //Arrange
            var fileStub = new Mock<IFile>();
            fileStub.Setup(f => f.Exists("TestPath")).Returns(false);

            //Act
            var CheckWaterUnitsFile = new CheckWaterUnitsFile("TestPath", fileStub.Object);

            //Assert
            Assert.That(() => CheckWaterUnitsFile.DataIsCorrect(), Throws.Exception.TypeOf<FileNotFoundException>());
        }

        [Test]
        public void DataIsCorrect_with_file_not_existing_should_throw_correct_error_message()
        {
            //Arrange
            var fileStub = new Mock<IFile>();
            fileStub.Setup(f => f.Exists("TestPath")).Returns(false);
            var CheckWaterUnitsFile = new CheckWaterUnitsFile("TestPath", fileStub.Object);

            //Act
            var ex = Assert.Throws<FileNotFoundException>(() => CheckWaterUnitsFile.DataIsCorrect());

            //Assert
            Assert.That(ex.Message, Is.EqualTo(ErrorStrings.PATH_NOT_FOUND));
        }

        [Test]
        public void DataIsCorrect_with_invalid_file_format_should_throw_InvalidDataException()
        {
            //Arrange
            var fileStub = new Mock<IFile>();
            fileStub.Setup(f => f.Exists("TestPath")).Returns(true);
            fileStub.Setup(f => f.ReadAllText("TestPath")).Returns("0");

            var CheckWaterUnitsFile = new CheckWaterUnitsFile("TestPath", fileStub.Object);

            //Assert
            Assert.That(() => CheckWaterUnitsFile.DataIsCorrect(), Throws.Exception.TypeOf<InvalidDataException>());
        }

        [Test]
        public void DataIsCorrect_with_invalid_file_format_should_throw_correct_error_message()
        {
            //Arrange
            var fileStub = new Mock<IFile>();
            fileStub.Setup(f => f.Exists("TestPath")).Returns(true);
            fileStub.Setup(f => f.ReadAllText("TestPath")).Returns("0");
            var CheckWaterUnitsFile = new CheckWaterUnitsFile("TestPath", fileStub.Object);

            //Act
            var ex = Assert.Throws<InvalidDataException>(() => CheckWaterUnitsFile.DataIsCorrect());

            //Assert
            Assert.That(ex.Message, Is.EqualTo(ErrorStrings.NOT_CSV_FORMAT));
        }

        [Test]
        public void DataIsCorrect_with_existing_file_and_valid_file_format_should_return_true()
        {
            //Arrange
            var fileStub = new Mock<IFile>();
            fileStub.Setup(f => f.Exists("TestPath")).Returns(true);
            fileStub.Setup(f => f.ReadAllText("TestPath")).Returns("1,2,3");

            var CheckWaterUnitsFile = new CheckWaterUnitsFile("TestPath", fileStub.Object);

            //Act
            var isDataCorrect = CheckWaterUnitsFile.DataIsCorrect();

            //Assert
            Assert.That(isDataCorrect, Is.EqualTo(true));
        }
    }
}
