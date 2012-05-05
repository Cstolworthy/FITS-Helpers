using System.Collections.Generic;
using Interfaces.Website;
using Interfaces.Website.Model;

namespace Objects.Website.Model
{
    public class ProcessModel : IProcessModel
    {
        private IUploadedFiles _uploadFiles;

        public ProcessModel(IUploadedFiles files)
        {
            _uploadFiles = files;
        }

        private Dictionary<string, string> _files;
        public Dictionary<string,string> Files
        {
            get { return _files ?? (_files = _uploadFiles.GetFilesToProcess()); }
        }
    }
}
