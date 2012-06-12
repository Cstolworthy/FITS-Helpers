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

        private static bool _registered = false;
        public static void RegisterBsonTypes()
        {
#warning this should really be somewhere else
            BsonClassMap.RegisterClassMap<FileImportRequest>();
        }

        public FitsImporterDataAccess(string mongoConnection)
        {
            _mongo = MongoServer.Create(mongoConnection);
            _mongo.Connect();

            _database = _mongo.GetDatabase(Constants.Database.Name);
            _importRequestCollection = _database.GetCollection<IFileImportRequest>(Constants.FitsImporter.ImportRequestCollectionName);

            lock (typeof(FitsImporterDataAccess))
            {
                if (!_registered)
                {
                    _registered = true;
                    RegisterBsonTypes();
                }
            }
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