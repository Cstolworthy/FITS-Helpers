using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using FitsLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FitsImporterTests
{
    [TestClass]
    public class FitsFileAccessTests
    {
        [TestMethod]
        public void TestImporterFindsUnprocessedFiles()
        {
            const int filesToCreate = 4;

            const int filesInProcess = 3;

            var importer = new FitsFileSystemSystemAccess();

            var tempFiles = CreateInprocessFiles(filesToCreate, filesInProcess);

            List<FileInfo> files = importer.GetFilesThatAreNotWorking(tempFiles.Item1.FullName);

            Assert.AreEqual(filesToCreate - filesInProcess, files.Count);
        }

        private static Tuple<DirectoryInfo, List<string>> CreateInprocessFiles(int nrFilesToCreate, int nrFilesInProcess)
        {
            var tempDir = Path.GetTempPath();

            tempDir = Path.Combine(tempDir, Path.GetRandomFileName());

            var di = new DirectoryInfo(tempDir);

            if (!di.Exists)
                di.Create();

            var randomFileNames = new List<string>();

            for (int i = 0; i < nrFilesToCreate; i++)
            {
                var fileName = Path.GetRandomFileName();

                File.Create(Path.Combine(tempDir, fileName));

                randomFileNames.Add(fileName);
            }

            for (int i = 0; i < nrFilesInProcess; i++)
            {
                File.Create(Path.Combine(tempDir, randomFileNames[i] + FitsFileSystemSystemAccess.WorkingExtension));
            }


            return new Tuple<DirectoryInfo, List<string>>(di, randomFileNames);
        }
    }
}
