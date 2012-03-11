using System;
using System.IO;
using FitsLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using nom.tam.fits;

namespace FitsLogicTests
{
    [TestClass]
    public class FitsImporterTests
    {
        [TestMethod]
        public void TestCtor()
        {
            var fi = new FitsImporter("mongo:\\", "");
        }

        [TestMethod]
        public void TestFitsNotInitializedIfFileEmpty()
        {
            var fi = new FitsImporter("mongo:\\", "");

            Assert.IsNull(fi.Fits);
        }

        [TestMethod]
        public void TestFitsInitializedIfFileNotEmpty()
        {
            var file = Path.GetTempFileName();

            var fi = new FitsImporter("mongo:\\", file);

            Assert.IsNotNull(fi.Fits);
        }

        [TestMethod]
        public void TestHduIsFetchedSafely()
        {
            var fi = new FitsImporter("mongo:\\", "");

            var fakeFits = new Mock<Fits>();

            fakeFits.Setup(ff => ff.ReadHDU()).Returns(delegate { throw new Exception(); });

            fi.Fits = fakeFits.Object;

            fi.FetchHduSafely();
        }

        [TestMethod]
        public void TestImageHduIsSortedCorrectly()
        {
            var fi = new Mock<FitsImporter>("mongo:\\", "");

            var fakeImageHandler = new Mock<ImageHduHandler>("");

            fi.SetupGet(img=>img.ImageHandler).Returns(fakeImageHandler.Object);

            var header = new Header();

            var imageHdu = new ImageHDU(header, null);

            fi.Setup(img => img.FetchHduSafely()).Returns(imageHdu);

            fi.Object.Parse("");

            fakeImageHandler.Verify(fih=>fih.Handle(It.IsAny<ImageHDU>()),Times.Once());
        }
    }
}
