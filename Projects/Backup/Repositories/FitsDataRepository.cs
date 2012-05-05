using System;
using System.Collections.Generic;
using InterfacesAndDto;
using InterfacesAndDto.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Utilities;

namespace Repositories
{
    public class FitsDataRepository : IFitsDataRepository
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

            _dataLinkerCollection = _db.GetCollection(Constants.Data.Linker.CollectionName);
        }
        
        public void GetRepositoriesAwaitingImport()
        {
            
        }
    }
}
#region OLD
//
//        public void CreateIndex(string columnName)
//        {
//            _dataCollection.CreateIndex(columnName);
//        }
//
//        public string SaveRow(Dictionary<string, string> values)
//        {
//            var doc = new BsonDocument();
//
//            foreach (var value in values)
//            {
//                double doubleValue;
//
//                if (double.TryParse(value.Value, out doubleValue))
//                {
//                    doc[value.Key] = doubleValue;
//                }
//                else
//                    doc[value.Key] = value.Value;
//            }
//
//            _dataCollection.Save(doc);
//
//            string idStr = doc[Constants.Id].ToString();
//
//            return idStr;
//        }
//
//        public string SaveLinker(List<string> idNames)
//        {
//            var array = new BsonArray(idNames);
//
//            var doc = new BsonDocument();
//
//            doc[Constants.Data.LinkerKey] = array;
//
//            _dataLinkerCollection.Save(doc);
//
//            return doc[Constants.Id].ToString();
//        }
//
//        public void SavePrimaryDocument(CollectionMap map)
//        {
//            _dataLinkerCollection.Save(map);
//        }
//
//        public List<CollectionMap> GetPrimaryDocuments()
//        {
//            var maps = _dataLinkerCollection.FindAll();
//
//            List<CollectionMap> collectionMaps = new List<CollectionMap>();
//            foreach (var map in maps)
//            {
//                var tempMap = new CollectionMap();
//                tempMap.PopulateFromMongo(map);
//                collectionMaps.Add(tempMap);
//            }
//
//            return collectionMaps;
//        }
//
//        public void SetDataCollectionName(string collectionName)
//        {
//            _dataCollection = _db.GetCollection(collectionName);
//        }
//
//        public long GetCollectionCount(string collectionName, int brick)
//        {
//            var coll =  _db.GetCollection(collectionName);
//            var query = Query.EQ("brick", brick);
//            return coll.Find(query).Count();
//        }
//
//        public MongoCursor<BsonDocument> Find(string collectionName, int offset, int limit, int brick)
//        {
//            var coll = _db.GetCollection(collectionName);
//            var query = Query.EQ("brick", brick);
//            var cursor = coll.Find(query);
//            cursor.SetSkip(offset);
//            cursor.SetLimit(limit);
//
//            return cursor;
//        }
#endregion OLD