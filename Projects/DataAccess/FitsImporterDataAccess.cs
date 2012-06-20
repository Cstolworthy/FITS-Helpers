using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Properties;
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

        public FitsImporterDataAccess()
        {
            _mongo = MongoServer.Create(Settings.Default.MongoConnection);
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

        public IEnumerable<IFileImportRequest> GetImportRequests()
        {
            return _importRequestCollection.FindAll().ToList();
        }

        public IEnumerable<IFileImportRequest> FindAllFileImportRequest()
        {
            var all = _importRequestCollection.FindAll();

            return all;
        }
    }
}