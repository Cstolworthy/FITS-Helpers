using System.Collections.Generic;
using BusinessLogic.FITS;
using Interfaces.DTO;
using Interfaces.FITS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FitsImporterTests
{
    [TestClass]
    public class ImporterTests
    {
        [TestMethod]
        public void TestFitsFileSystemImporterGetsUnprocessedFiles()
        {
            var mockFileAccess = new Mock<IFitsFileAccess>();
            var mockFitsRepository = new Mock<IFitsMapper>();

            var mockFileImport = new Mock<IFileImportOptions>();
            mockFileImport.SetupGet(fi => fi.FilePath).Returns("c:\\");

            mockFitsRepository.Setup(fr => fr.GetFilesWaitingImport()).Returns(new List<IFileImportOptions> { mockFileImport.Object });

            var importer = new FitsFileFileImporter(mockFileAccess.Object, "", mockFitsRepository.Object);

            importer.ProcessWaitingFiles();

            mockFitsRepository.Verify(fr => fr.GetFilesWaitingImport());
            //
        }

        [TestMethod]
        public void TestWhenBeginImportIsCalledTheRepositoryIsNotifiedOfNewImport()
        {
            var mockFileAccess = new Mock<IFitsFileAccess>();
            var mockFitsRepository = new Mock<IFitsMapper>();


            var mockFileImport = new Mock<IFileImportOptions>();
            mockFileImport.SetupGet(fi => fi.FilePath).Returns("c:\\");

            mockFitsRepository.Setup(fr => fr.GetFilesWaitingImport()).Returns(new List<IFileImportOptions> { mockFileImport.Object });

            var importer = new FitsFileFileImporter(mockFileAccess.Object, "", mockFitsRepository.Object);

            importer.BeginImport(null, null);

            mockFitsRepository.Verify(fr=>fr.CreateNewImport(It.IsAny<IFileImportOptions>()));
        }

        [TestMethod]
        public void TestWhenScanForNewFilesIsCalledTheCorrectMethodIsUsedOnFileAccess()
        {
            var mockFileAccess = new Mock<IFitsFileAccess>();
            var mockFitsRepository = new Mock<IFitsMapper>();


            var mockFileImport = new Mock<IFileImportOptions>();
            mockFileImport.SetupGet(fi => fi.FilePath).Returns("c:\\");

            mockFitsRepository.Setup(fr => fr.GetFilesWaitingImport()).Returns(new List<IFileImportOptions> { mockFileImport.Object });

            var importer = new FitsFileFileImporter(mockFileAccess.Object, "", mockFitsRepository.Object);

            importer.ScanForNewFiles();

            mockFileAccess.Verify(fa=>fa.GetFilesThatAreNotFound(""));
        }
    }


}
