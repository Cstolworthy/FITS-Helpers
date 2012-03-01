using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace InterfacesAndDTO
{
    public class BsonDynamic
    {
        public BsonObjectId BsonId { get; set; }
        public dynamic Fits { get; set; }
    }
}
