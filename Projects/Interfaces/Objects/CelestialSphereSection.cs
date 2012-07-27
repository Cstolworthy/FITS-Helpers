using Objects;

namespace Interfaces.Objects
{
    public class CelestialSphereSection : ICelestialSphereSection
    {
        public CelestialSphereSection(decimal rightAscension, decimal declination, ColorIntensityCollection colorIntensity, long brick, long field)
        {
            RightAscension = rightAscension;
            Declination = declination;
            ColorIntensity = colorIntensity;
            Brick = brick;
            Field = field;
        }

        public decimal RightAscension { get; private set; }
        public decimal Declination { get; private set; }
        public long Brick { get; private set; }
        public long Field { get; private set; }
        public ColorIntensityCollection ColorIntensity { get; private set;}
    }
}
