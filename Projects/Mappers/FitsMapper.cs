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
        private readonly IFitsImporterDataAccess _dbAccess;
        private BsonDocument _document;

        public FitsMapper(IFitsImporterDataAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        public void CreateNewImport(IFileImportOptions option)
        {
        }

        public IEnumerable<IFileImportOptions> GetFilesWaitingImport()
        {
            throw new NotImplementedException();
        }

        public void CreateNewDocument()
        {
            _document = new BsonDocument();
        }

        public void SetValue(string columnName, object columnValue)
        {
        }

        public void SaveDocument()
        {
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
