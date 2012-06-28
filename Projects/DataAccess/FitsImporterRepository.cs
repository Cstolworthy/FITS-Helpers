using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Properties;
using Interfaces.DataAccess;
using Interfaces.DTO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Objects;
using Objects.DTO;

namespace DataAccess
{
    public class FitsImporterRepository : IFitsImporterRepository
    {
        private readonly MongoServer _mongo;
        private MongoDatabase _database;
        private MongoCollection<IFileImportRequest> _importRequestCollection;
        private MongoCollection<BsonDocument> _currentCollection;

        private static bool _registered = false;
        public static void RegisterBsonTypes()
        {
#warning this should really be somewhere else
            BsonClassMap.RegisterClassMap<FileImportRequest>();
        }

        public FitsImporterRepository()
        {
            _mongo = MongoServer.Create(Settings.Default.MongoConnection);
            _mongo.Connect();

            _database = _mongo.GetDatabase(Constants.Database.Name);
            _importRequestCollection = _database.GetCollection<IFileImportRequest>(Constants.FitsImporter.ImportRequestCollectionName);

            lock (typeof(FitsImporterRepository))
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

        public void CreateNewCollection(string fileNameAndPath)
        {
            _currentCollection = _database.GetCollection(fileNameAndPath);
        }

        public void SaveDocumentToOpenCollection(BsonDocument document)
        {
            _currentCollection.Save(document);
        }

        public IEnumerable<IFileImportRequest> FindAllFileImportRequest()
        {
            var all = _importRequestCollection.FindAll();

            return all;
        }
    }
}