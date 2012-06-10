using System.Collections.Generic;
using Interfaces.DataAccess;
using Interfaces.DTO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Objects;
using Objects.DTO;

namespace DataAccess
{
    public class FitsImporterDataAccess : IFitsImporterDataAccess
    {
        private readonly MongoServer _mongo;
        private MongoDatabase _database;
        private MongoCollection<IFileImportRequest> _importRequestCollection;

        public FitsImporterDataAccess(string mongoConnection)
        {
            _mongo = MongoServer.Create(mongoConnection);
            _mongo.Connect();

            _database = _mongo.GetDatabase(Constants.Database.Name);
            _importRequestCollection = _database.GetCollection<IFileImportRequest>(Constants.FitsImporter.ImportRequestCollectionName);

            BsonClassMap.RegisterClassMap<FileImportRequest>();
        }

        public void Save(IFileImportRequest fileRequest)
        {
            _importRequestCollection.Save(fileRequest);
        }

        public IEnumerable<IFileImportRequest> FindAllFileImportRequest()
        {
            var all = _importRequestCollection.FindAll();

            return all;
        }
    }
}