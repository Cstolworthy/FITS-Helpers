using System.Collections.Generic;
using System.IO;

namespace Interfaces.FITS
{
    public interface IFitsFileAccess
    {
        List<FileInfo> GetUnprocessedFiles(string path);
    }
}
