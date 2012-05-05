using System;
using System.Collections.Generic;
using InterfacesAndDTO.Interfaces.Repositories;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using nom.tam.fits;

namespace Repositories
{
    public class FitsImageRepository : IFitsImageRepository
    {
        private readonly MongoServer _mongo;
        private readonly MongoDatabase _db;
        private readonly MongoCollection<BsonDocument> _imageLinkCollection;
        private readonly MongoCollection<BsonDocument> _dataCollection;

        readonly string[] _fieldNames = { "Author", "BitPix", "BlankValue", "BScale", "BUnit", "BZero", "CreationDate", "Epoch",
                                  "Equinox", "FileOffset", "GroupCount", "Instrument", "MaximumValue", "MinimumValue", "Object", "ObservationDate",
                                  "Observer", "Origin", "ParameterCount", "Reference", "Rewriteable", "Size", "Telescope"};

        public FitsImageRepository()
        {
            _mongo = MongoServer.Create("mongodb://127.0.0.1:27017");
            _mongo.Connect();

            _db = _mongo.GetDatabase(Constants.FitsImage.DatabaseName);

            _imageLinkCollection = _db.GetCollection(Constants.FitsImage.ImageLinks);
            _dataCollection = _db.GetCollection(Constants.FitsImage.ImagesData);
        }

        public void InsertImageData(string imageName, ImageHDU hdu)
        {
            var document = ConvertDataToDocumentArray(hdu);
            document[Constants.FitsImage.ImageName] = imageName;
            AddFitsDataToDocument(hdu, document);

            _imageLinkCollection.Save(document);

        }

        private void AddFitsDataToDocument(ImageHDU hdu, BsonDocument document)
        {
            

            foreach (var fieldName in _fieldNames)
            {
                PopulateField(fieldName, document, hdu);
            }
        }

        private static void PopulateField(string fieldName, BsonDocument bsonDocument, ImageHDU hdu)
        {
            try
            {
                var property = hdu.GetType().GetProperty(fieldName);

                var value = property.GetValue(hdu, null);

                if (value != null)
                    bsonDocument[fieldName] = value.ToString();
            }
            catch (Exception e)
            { }
        }

        private BsonDocument ConvertDataToDocumentArray(ImageHDU hdu)
        {
            var documents = new List<BsonDocument>();

            var data = hdu.Tiler.CompleteImage as Array[];

            ExtractArrays(data, documents);

            var linker = new BsonDocument();
            var idArray = new BsonArray();
            foreach (var document in documents)
            {
                object id;
                Type nominalType;
                IIdGenerator idGen;
                if (document.GetDocumentId(out id, out nominalType, out idGen))
                {
                    idArray.Add(id.ToString());
                }
            }
            linker[Constants.FitsImage.ImagesLinker] = idArray;
            _imageLinkCollection.Save(linker);

            return linker;
        }

        private void ExtractArrays(Array[] data, List<BsonDocument> documents)
        {
            if (data.Length < 10)
            {
                var linkDocument = new BsonDocument();
                BsonArray linkedListOfDocs = new BsonArray();

                foreach (var array in data)
                {
                    BsonArray linkedDocs = new BsonArray();
                    foreach (var embeddedArray in array)
                    {
                        var doc = new BsonDocument();
                        CompressArray((Array)embeddedArray, doc);

//                        documents.Add(doc);
                        _dataCollection.Save(doc);

                        object id;
                        Type nominalType;
                        IIdGenerator generator;

                        if(doc.GetDocumentId(out id, out nominalType,out generator))
                        {
                            linkedDocs.Add(id.ToString());
                        }
                    }

                    linkedListOfDocs.Add(linkedDocs);

                }
                linkDocument[Constants.FitsImage.ImageLinks] = linkedListOfDocs;
                _dataCollection.Save(linkDocument);
                documents.Add(linkDocument);
            }
            else
            {
                foreach (var array in data)
                {
                    var doc = new BsonDocument();
                    doc[Constants.FitsImage.ImagesData] = new BsonArray(array);

                    documents.Add(doc);
                    _dataCollection.Save(doc);
                }
            }
        }

        private void CompressArray(Array embeddedArray, BsonDocument document)
        {
            for (int i = 0; i < embeddedArray.Length; i++)
            {
                var value = (float)embeddedArray.GetValue(i);

                if(value != 0)
                {
                    document[i.ToString()] = value;
                }
            }
        }
    }
}
