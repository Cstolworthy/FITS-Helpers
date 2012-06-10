using System.Collections.Generic;
using System.IO;
using System.Linq;
using Interfaces.FITS;

namespace FitsLogic
{
    public class FitsFilesystemAccess : IFitsFileAccess
    {
        public const string WorkingExtension = ".wrk";

        public List<FileInfo> GetUnprocessedFiles(string path)
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

        private static bool FindWorkingMatch(IEnumerable<FileInfo> files, FileInfo fileInfo)
        {
            var workingSet = files.Where(fi => Path.GetExtension(fi.Name) == WorkingExtension);

            return workingSet.Any(info => Path.GetFileNameWithoutExtension(info.Name.ToLower()) == fileInfo.Name.ToLower());
        }
    }
}
