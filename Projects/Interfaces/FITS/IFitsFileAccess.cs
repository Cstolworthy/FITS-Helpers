using System.Collections.Generic;
using System.IO;

namespace Interfaces.FITS
{
    public interface IFitsFileAccess
    {
        List<FileInfo> GetFilesThatAreNotWorking(string path);
        List<FileInfo> GetFilesThatAreNotFound(string path);
    }
}
