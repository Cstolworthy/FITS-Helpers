using Interfaces;
using Interfaces.Collections;
using MongoDB.Bson;

namespace Core.Objects
{
    public class CelestialSphereSection : ICelestialSphereSection
    {
        public CelestialSphereSection(double rightAscension, double declination, ColorIntensityCollection colorIntensity, long? brick, long? field)
        {
            RightAscension = rightAscension;
            Declination = declination;
            ColorIntensity = colorIntensity;
            Brick = brick;
            Field = field;
        }

        public BsonObjectId ObjectId { get; set; }
        public double RightAscension { get; private set; }
        public double Declination { get; private set; }
        public long? Brick { get; private set; }
        public long? Field { get; private set; }
        public ColorIntensityCollection ColorIntensity { get; private set; }
    }
}
