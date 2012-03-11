using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Repositories
{
    public class FitsDataRepository
    {
        private string _mongoConnection;
        private readonly MongoServer _mongo;
        private readonly MongoDatabase _db;
        private readonly MongoCollection<BsonDocument> _dataCollection;
        private MongoCollection<BsonDocument> _dataLinkerCollection;

        readonly string[] _fieldNames = { "Author", "BitPix", "BlankValue", "BScale", "BUnit", "BZero", "CreationDate", "Epoch",
                                  "Equinox", "FileOffset", "GroupCount", "Instrument", "MaximumValue", "MinimumValue", "Object", "ObservationDate",
                                  "Observer", "Origin", "ParameterCount", "Reference", "Rewriteable", "Size", "Telescope"};



        public FitsDataRepository(string mongoConnection)
        {
            _mongoConnection = mongoConnection;

            _mongo = MongoServer.Create(mongoConnection);
            _mongo.Connect();

            _db = _mongo.GetDatabase(Constants.DatabaseName);

            _dataCollection = _db.GetCollection(Constants.Data.CollectionName);
            _dataLinkerCollection = _db.GetCollection(Constants.Data.Linker.CollectionName);
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

        public void SavePrimaryDocument(List<string> linkIds)
        {
            var array = new BsonArray(linkIds);

            var doc = new BsonDocument();

            doc[Constants.Data.LinkerKey] = array;

            _dataLinkerCollection.Save(doc);


        }
    }
}
