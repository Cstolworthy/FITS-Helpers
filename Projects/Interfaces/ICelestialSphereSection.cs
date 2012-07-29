using Interfaces.Collections;
using Interfaces.Marker;
using MongoDB.Bson;

namespace Interfaces
{
    public interface ICelestialSphereSection : IValueObject
    {
        BsonObjectId ObjectId { get; set; }
        double RightAscension { get; }
        double Declination { get; }
        long? Brick { get; }
        long? Field { get; }
        ColorIntensityCollection ColorIntensity { get; }
    }
}