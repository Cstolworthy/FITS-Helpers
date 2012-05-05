using System.Collections.Generic;
using System.IO;
using System.Linq;
using Interfaces.Website;

namespace Objects.Website
{
    public class UploadedFiles : IUploadedFiles
    {
        private readonly string _uploadPath;
        private string _processedPath;

        public UploadedFiles(string uploadPath, string processedPath)
        {
            _uploadPath = uploadPath;
            _processedPath = processedPath;
        }

        public Dictionary<string,string> GetFilesToProcess()
        {
            var di = new DirectoryInfo(_uploadPath);

            var allFiles = di.GetFiles();

            var files = new Dictionary<string, string>();

            foreach (var fileInfo in allFiles)
            {
                bool shouldSkip = false;
                shouldSkip = File.Exists(fileInfo.FullName + ".wrk") || fileInfo.Extension == ".wrk";

                if (shouldSkip)
                {
                    continue;
                }

                files.Add(fileInfo.Name,fileInfo.FullName);
            }
            
            return files;
        }

        public void MarkFileAsWorking(string fullFileName)
        {
            File.Create(fullFileName + ".wrk");
        }
        
    }
}
