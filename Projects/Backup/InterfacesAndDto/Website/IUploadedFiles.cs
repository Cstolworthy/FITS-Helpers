using System.Collections.Generic;

namespace Interfaces.Website
{
    public interface IUploadedFiles
    {
        Dictionary<string, string> GetFilesToProcess();
    }
}
