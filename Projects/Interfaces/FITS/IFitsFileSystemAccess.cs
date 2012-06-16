using System.Collections.Generic;
using System.IO;
using Interfaces.Marker;

namespace Interfaces.FITS
{
    public interface IFitsFileSystemAccess : IService
    {
        List<FileInfo> GetFilesThatAreNotWorking(string path);
        List<FileInfo> GetFilesThatAreNotFound(string path);
    }
}
