using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Interfaces.DTO
{
    public interface IFileImportRequest
    {
        [BsonId(IdGenerator = typeof(BsonObjectIdGenerator))]
        ObjectId Id { get; set; }

        [BsonRequired]
        string FileNameAndPath { get; set; }

        DateTime FoundOn { get; set; }
    }
}