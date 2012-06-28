using System.Collections.Generic;
using System.IO;
using Interfaces.DTO;
using Interfaces.Marker;

namespace Interfaces.FITS
{
    public interface IFitsContext : IContext
    {
        IEnumerable<string> GetColumnHeaders(FileInfo file);
        IEnumerable<IFileImportRequest> GetImportRequests();
    }
}
