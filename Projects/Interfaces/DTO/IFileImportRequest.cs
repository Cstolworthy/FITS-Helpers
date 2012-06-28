using System;
using Interfaces.Marker;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Interfaces.DTO
{
    public interface IFileImportRequest : IValueObject
    {
        [BsonId(IdGenerator = typeof(BsonObjectIdGenerator))]
        ObjectId Id { get; set; }

        [BsonRequired]
        string FileNameAndPath { get; set; }

        DateTime FoundOn { get; set; }
        string DecColumn { get; set; }
        string RaColumn { get; set; }
    }
}