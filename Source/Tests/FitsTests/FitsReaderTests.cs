using Core;
using NUnit.Framework;

namespace FitsTests
{
    [TestFixture]
    public class FitsReaderTests
    {
        private FitsImporter _importer;
        private string _filePath = "FilePath";

        [SetUp]
        public void SetUp()
        {
            _importer = new FitsImporter(_filePath);
        }

        [Test]
        public void GivenAFilePath_ImportFITS_RetrievesHDU()
        {
            _importer.ImportFits();
        }
    }
}