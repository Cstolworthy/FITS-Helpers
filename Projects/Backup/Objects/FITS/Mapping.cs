using System;
using Interfaces.FITS;
using InterfacesAndDto;
using MongoDB.Bson.Serialization.Attributes;

namespace Objects.FITS
{
    public class Mapping : IMapping
    {
        [BsonId]
        public virtual Guid Id { get; set; }
        public virtual IHeader Header { get; set; }
        public virtual IMetaData MetaData { get; set; }
        public virtual CollectionStatus Status { get; set; }
        public virtual long CollectionSize { get; set; }
        public virtual double LargestRa { get; set; }
        public virtual double SmallestRa { get; set; }
        public virtual double LargestDec { get; set; }
        public virtual double SmallestDec { get; set; }
    }
}
