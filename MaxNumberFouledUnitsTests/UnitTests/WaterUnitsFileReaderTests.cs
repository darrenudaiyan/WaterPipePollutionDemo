using System;
using System.Collections.Generic;
using System.IO;
using Udaiyan.MaxNumberFouledUnits.DataProviders;
using Udaiyan.MaxNumberFouledUnits.StringProviders;
using Udaiyan.MaxNumberFouledUnits.Stubs;
using Moq;
using NUnit.Framework;

namespace Udaiyan.MaxNumberFouledUnitsTests.UnitTests
{
    [TestFixture]
    public class WaterUnitsFileReaderTests
    {
        [Test]
        public void WaterUnitsFileReader_with_null_path_should_throw_ArgumentNullException()
        {
            //Assert
            Assert.That(() => new WaterUnitsFileReader(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void WaterUnitsFileReader_with_null_path_should_throw_correct_error_message()
        {
            //Arrange

            //Act
            var ex = Assert.Throws<ArgumentNullException>(() => new WaterUnitsFileReader(null));

            //Assert
            Assert.That(ex.Message, Is.EqualTo(ErrorStrings.NULL_PATH_FILE + "\r\nParameter name: WaterUnitsFilePath"));
        }

        [Test]
        public void WaterUnitsFileReader_with_null_file_should_throw_ArgumentNullException()
        {
            //Assert
            Assert.That(() => new WaterUnitsFileReader("TestPath", null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void WaterUnitsFileReader_with_null_file_should_throw_correct_error_message()
        {
            //Arrange

            //Act
            var ex = Assert.Throws<ArgumentNullException>(() => new WaterUnitsFileReader("TestPath", null));

            //Assert
            Assert.That(ex.Message, Is.EqualTo(ErrorStrings.NULL_FILE + "\r\nParameter name: file"));
        }

        [Test]
        public void WaterUnitsFileReader_with_missing_file_should_throw_FileNotFoundException()
        {
            //Arrange
            var fileStub = new Mock<IFile>();
            fileStub.Setup(f => f.Exists("TestPath")).Returns(false);

            //Assert
            Assert.That(() => new WaterUnitsFileReader("TestPath", fileStub.Object), Throws.Exception.TypeOf<FileNotFoundException>());
        }

        [Test]
        public void WaterUnitsFileReader_with_missing_file_should_throw_correct_error_message()
        {
            //Arrange
            var fileStub = new Mock<IFile>();
            fileStub.Setup(f => f.Exists("TestPath")).Returns(false);

            //Act
            var ex = Assert.Throws<FileNotFoundException>(() => new WaterUnitsFileReader("TestPath", fileStub.Object));

            //Assert
            Assert.That(ex.Message, Is.EqualTo(ErrorStrings.PATH_NOT_FOUND));
        }

        [Test]
        public void WaterUnitsFileReader_with_duplicate_WaterUnits_should_throw_InvalidOperationException()
        {
            //Arrange
            string[] WaterUnits = { "Pipe1,Tank2,Pipe1", "Tank2,Tank3,Tank4" };
            var fileStub = new Mock<IFile>();
            fileStub.Setup(f => f.Exists("TestPath")).Returns(true);
            fileStub.Setup(f => f.ReadLines("TestPath")).Returns(WaterUnits);
            var WaterUnitsFileReader = new WaterUnitsFileReader("TestPath", fileStub.Object);

            //Assert
            Assert.That(() => WaterUnitsFileReader.GetWaterUnitsLists(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void WaterUnitsFileReader_with_duplicate_WaterUnits_should_throw_correct_error_message()
        {
            //Arrange
            string[] WaterUnits = { "Pipe1,Tank2,Pipe1", "Tank2,Tank3,Tank4" };
            var fileStub = new Mock<IFile>();
            fileStub.Setup(f => f.Exists("TestPath")).Returns(true);
            fileStub.Setup(f => f.ReadLines("TestPath")).Returns(WaterUnits);
            var WaterUnitsFileReader = new WaterUnitsFileReader("TestPath", fileStub.Object);

            //Act
            var ex = Assert.Throws<InvalidOperationException>(() => WaterUnitsFileReader.GetWaterUnitsLists());

            //Assert
            Assert.That(ex.Message.Contains(ErrorStrings.DUPLICATE_WaterUnits));
        }

        [Test]
        public void GetWaterUnitsLists_with_existing_file_and_valid_file_format_should_return_correct_data_format()
        {
            //Arrange
            string[] WaterUnits = { "Pipe1,Pipe2,Pipe3", "Pipe2,Pipe5,Pipe6" };
            var fileStub = new Mock<IFile>();
            fileStub.Setup(f => f.Exists("TestPath")).Returns(true);
            fileStub.Setup(f => f.ReadLines("TestPath")).Returns(WaterUnits);
            var WaterUnitsFileReader = new WaterUnitsFileReader("TestPath", fileStub.Object);

            //Act
            var WaterUnitsLists = WaterUnitsFileReader.GetWaterUnitsLists();

            //Assert
            Assert.That(WaterUnitsLists, Is.TypeOf<List<List<string>>>());
        }
    }
}
