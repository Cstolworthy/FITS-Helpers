using System.Collections.Generic;
using System.IO;
using System.Web;
using FitsLogic;
using Interfaces.Website;
using Interfaces.Website.Model;

namespace Objects.Website.Model
{
    public class DesignateModel : IDesignateModel
    {
        private IUploadedFiles _files;
        public string SelectedFile { get; set; }
        private string SelectedFileWithPath { get; set; }

        public DesignateModel(IUploadedFiles files)
        {
            _files = files;
        }

        public List<string> GetColumnNames()
        {
            bool found = false;

            var files = _files.GetFilesToProcess();

            foreach (var file in files)
            {
                var decodedkey = HttpUtility.UrlDecode(file.Key);

                if (decodedkey.ToLower() == SelectedFile.ToLower())
                {
                    SelectedFileWithPath = file.Value;
                    found = true;
                    break;
                }
            }

            if(found)
            {
                var hd = new FitsHandler(new FileInfo(SelectedFileWithPath));

                return hd.Columns;
            }

            return new List<string>();
        }
    }
}
