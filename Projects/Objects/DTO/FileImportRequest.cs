using System;
using Interfaces.DTO;
using MongoDB.Bson;

namespace Objects.DTO
{
    public class FileImportRequest : IFileImportRequest
    {
        public ObjectId Id { get; set; }
      
        public string FileNameAndPath { get; set; }

        public DateTime FoundOn { get; set; }
    }
}