using System.Collections.Generic;
using FitsLogic;
using Interfaces;
using Interfaces.FITS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using nom.tam.fits;

namespace FitsImporterTests
{
    [TestClass]
    public class ImporterTests
    {
        [TestMethod]
        public void TestFitsFileSystemImporterGetsUnprocessedFiles()
        {
            var mockFileAccess = new Mock<IFitsFileAccess>();
            var mockFitsRepository = new Mock<IFitsRepository>();

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
            var mockFitsRepository = new Mock<IFitsRepository>();


            var mockFileImport = new Mock<IFileImportOptions>();
            mockFileImport.SetupGet(fi => fi.FilePath).Returns("c:\\");

            mockFitsRepository.Setup(fr => fr.GetFilesWaitingImport()).Returns(new List<IFileImportOptions> { mockFileImport.Object });

            var importer = new FitsFileFileImporter(mockFileAccess.Object, "", mockFitsRepository.Object);

            importer.BeginImport(null);

            mockFitsRepository.Verify(fr=>fr.CreateNewImport(It.IsAny<BasicHDU>()));
        }
    }


}
