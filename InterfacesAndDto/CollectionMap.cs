using System;
using MongoDB.Bson.Serialization.Attributes;

namespace InterfacesAndDto
{
    public class CollectionMap
    {
        [BsonId]
        public Guid Id { get; set; }
        public string CollectionName { get; set; }
        public int RecordCount { get; set; }
        public string Author { get; set; }
        public int BitPix { get; set; }
        public string BlankValue { get; set; }
        public double BScale { get; set; }
        public string BUnit { get; set; }
        public double BZero { get; set; }
        public DateTime CreationDate { get; set; }
        public double Epoch { get; set; }
        public double Equinox { get; set; }
        public long FileOffset { get; set; }
        public int GroupCount { get; set; }
        public string Instrument { get; set; }
        public double MaximumValue { get; set; }
        public double MinimumValue { get; set; }
        public string Object { get; set; }
        public DateTime ObservationDate { get; set; }
        public string Observer { get; set; }
        public string Origin { get; set; }
        public int ParameterCount { get; set; }
        public string Reference { get; set; }
        public bool Rewriteable { get; set; }
        public long Size { get; set; }
        public string Telescope { get; set; }
        public DateTime InsertDate { get; set; }
        public CollectionStatus Status { get; set; }
        public int LastRecordIndex { get; set; }
    }
}
