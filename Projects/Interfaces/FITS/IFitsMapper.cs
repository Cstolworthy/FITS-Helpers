using System.Collections.Generic;
using System.IO;
using Interfaces.DTO;
using Interfaces.Marker;

namespace Interfaces.FITS
{
    public interface IFitsMapper : IMapper
    {
        void CreateNewImport(IFileImportOptions hdu);
        IEnumerable<IFileImportOptions> GetFilesWaitingImport();
        void CreateNewDocument();
        void SetValue(string columnName, object columnValue);
        void SaveDocument();
        void CreateNewFileImportRequest(FileInfo fileInfo);
    }
}
