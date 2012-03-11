using System;
using System.Collections.Generic;
using InterfacesAndDto;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Repositories
{
    public class FitsDataRepository
    {
        private readonly MongoServer _mongo;
        private readonly MongoDatabase _db;
        private MongoCollection<BsonDocument> _dataCollection;
        private MongoCollection<BsonDocument> _dataLinkerCollection;

        public FitsDataRepository(string mongoConnection)
        {
            _mongo = MongoServer.Create(mongoConnection);
            _mongo.Connect();

            _db = _mongo.GetDatabase(Constants.DatabaseName);

            //            _dataCollection = _db.GetCollection(Constants.Data.CollectionName);
            _dataLinkerCollection = _db.GetCollection(Constants.Data.Linker.CollectionName);
        }

        public void CreateIndex(string columnName)
        {
            _dataCollection.CreateIndex(columnName);
        }

        public string SaveRow(Dictionary<string, string> values)
        {
            var doc = new BsonDocument();

            foreach (var value in values)
            {
                double doubleValue;

                if (double.TryParse(value.Value, out doubleValue))
                {
                    doc[value.Key] = doubleValue;
                }
                else
                    doc[value.Key] = value.Value;
            }

            _dataCollection.Save(doc);

            string idStr = doc[Constants.Id].ToString();

            return idStr;
        }

        public string SaveLinker(List<string> idNames)
        {
            var array = new BsonArray(idNames);

            var doc = new BsonDocument();

            doc[Constants.Data.LinkerKey] = array;

            _dataLinkerCollection.Save(doc);

            return doc[Constants.Id].ToString();
        }

        public void SavePrimaryDocument(CollectionMap map)
        {
            _dataLinkerCollection.Save(map);
        }

        public void SetDataCollectionName(string collectionName)
        {
            _dataCollection = _db.GetCollection(collectionName);
        }
    }
}
