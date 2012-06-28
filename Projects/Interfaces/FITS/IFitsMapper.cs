using System.Collections.Generic;
using System.IO;
using Interfaces.DTO;
using Interfaces.Marker;
using MongoDB.Bson;

namespace Interfaces.FITS
{
    public interface IFitsMapper : IMapper
    {
        void CreateNewImport(IFileImportRequest hdu);
        IEnumerable<IFileImportOptions> GetFilesWaitingImport();
        void CreateNewDocument();
        void SetValue<T>(string columnName, T columnValue) where T : BsonValue; 
        void SaveDocument();
        void CreateNewFileImportRequest(FileInfo fileInfo);
        void SaveNewFileImportRequest(IFileImportRequest request);
        void SaveDocument(BsonDocument doc);
    }
}
