using System;
using System.Collections.Generic;
using System.IO;
using Interfaces;
using Interfaces.DataAccess;
using Interfaces.DTO;
using Interfaces.FITS;
using MongoDB.Bson;
using Objects.DTO;

namespace Mappers
{
    public class FitsMapper : IFitsMapper
    {
        private readonly IFitsImporterRepository _dbAccess;
        private BsonDocument _document;

        public FitsMapper(IFitsImporterRepository dbAccess)
        {
            _dbAccess = dbAccess;
        }

        public void CreateNewImport(IFileImportRequest hdu)
        {
            _dbAccess.CreateNewCollection("temp");
        }

        public IEnumerable<IFileImportOptions> GetFilesWaitingImport()
        {
            throw new NotImplementedException();
        }

        public void CreateNewDocument()
        {
            _document = new BsonDocument();
        }

        public void SetValue<T>(string columnName, T columnValue) where T : BsonValue
        {
            _document[columnName] = columnValue;
        }

        public void SaveDocument()
        {
            _dbAccess.SaveDocumentToOpenCollection(_document);
        }

        public void SaveDocument(BsonDocument doc)
        {
            _dbAccess.SaveDocumentToOpenCollection(doc);
        }

        public void CreateNewFileImportRequest(FileInfo fileInfo)
        {
            //            var import = new FileImportRequest {FileNameAndPath = fileInfo.FullName, FoundOn = DateTime.UtcNow};

            //            _dbAccess.Save(import);
        }

        public void SaveNewFileImportRequest(IFileImportRequest request)
        {
            _dbAccess.Save(request);
        }

      
    }
}
