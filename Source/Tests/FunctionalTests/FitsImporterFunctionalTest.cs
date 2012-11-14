using Core;
using NUnit.Framework;

namespace FunctionalTests
{
    [TestFixture]
    public class FitsImporterFunctionalTest
    {
        private FitsImporter _importer;
        private string FileLocation = @"D:\temp\FITS\m1_041117_9i45m_L.FIT";

        [SetUp]
        public void SetUp()
        {
            _importer = new FitsImporter(FileLocation);
        }

        [Test]
        public void Test()
        {
            _importer.ImportFits();
        }

    }
}