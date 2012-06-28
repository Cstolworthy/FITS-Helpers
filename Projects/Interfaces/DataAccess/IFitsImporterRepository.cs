using System.Collections.Generic;
using Interfaces.DTO;
using Interfaces.Marker;
using MongoDB.Bson;

namespace Interfaces.DataAccess
{
    public interface IFitsImporterRepository : IRepository
    {
        void Save(IFileImportRequest fileRequest);
        IEnumerable<IFileImportRequest> GetImportRequests();
        void CreateNewCollection(string fileNameAndPath);
        void SaveDocumentToOpenCollection(BsonDocument document);
    }
}