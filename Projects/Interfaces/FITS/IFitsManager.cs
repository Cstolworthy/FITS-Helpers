using System.Collections.Generic;
using System.IO;
using Interfaces.Marker;

namespace Interfaces.FITS
{
    public interface IFitsManager : IManager
    {
        IEnumerable<string> GetColumnHeaders(FileInfo file);
    }
}
