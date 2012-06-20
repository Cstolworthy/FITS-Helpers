using System.Collections.Generic;
using System.IO;
using Interfaces.DTO;
using Interfaces.Marker;

namespace Interfaces.FITS
{
    public interface IFitsManager : IManager
    {
        IEnumerable<string> GetColumnHeaders(FileInfo file);
        IEnumerable<IFileImportRequest> GetImportRequests();
    }
}
