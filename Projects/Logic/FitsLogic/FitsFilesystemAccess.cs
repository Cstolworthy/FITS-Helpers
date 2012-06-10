using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Interfaces.FITS;

namespace FitsLogic
{
    public class FitsFileSystemAccess : IFitsFileAccess
    {
        public const string WorkingExtension = ".wrk";
        public const string FoundExtension = ".fnd";

        public List<FileInfo> GetFilesThatAreNotWorking(string path)
        {
            var unprocessedFiles = new List<FileInfo>();

            var di = new DirectoryInfo(path);

            if (di.Exists)
            {
                var files = di.GetFiles();

                var filteredFiles = files.Where(fi => Path.GetExtension(fi.Name) != WorkingExtension);

                unprocessedFiles.AddRange(filteredFiles.Where(fileInfo => !FindWorkingMatch(files, fileInfo)));
            }

            return unprocessedFiles;
        }

        public List<FileInfo> GetFilesThatAreNotFound(string path)
        {
            var unprocessedFiles = new List<FileInfo>();

            var di = new DirectoryInfo(path);

            if (di.Exists)
            {
                var files = di.GetFiles();

                var filteredFiles = files.Where(fi => Path.GetExtension(fi.Name) != WorkingExtension);

                unprocessedFiles.AddRange(filteredFiles.Where(fileInfo => !FindFoundMatch(files, fileInfo)));
            }

            return unprocessedFiles;
        }

        private static bool FindFoundMatch(IEnumerable<FileInfo> files, FileInfo fileInfo)
        {
            var workingSet = files.Where(fi => Path.GetExtension(fi.Name) == FoundExtension);

            return workingSet.Any(info => Path.GetFileNameWithoutExtension(info.Name.ToLower()) == fileInfo.Name.ToLower());
        }

        private static bool FindWorkingMatch(IEnumerable<FileInfo> files, FileInfo fileInfo)
        {
            var workingSet = files.Where(fi => Path.GetExtension(fi.Name) == WorkingExtension);

            return workingSet.Any(info => Path.GetFileNameWithoutExtension(info.Name.ToLower()) == fileInfo.Name.ToLower());
        }
    }
}
