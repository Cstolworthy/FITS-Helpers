using System.Collections.Generic;
using Interfaces.Marker;

namespace Interfaces.Objects
{
    public interface ICelestialSphereSection : IValueObject
    {
        decimal RightAscension { get; }
        decimal Declination { get; }
        long Brick { get; }
        long Field { get; }
        IEnumerable<KeyValuePair<string, decimal>> ColorIntensity { get; }
    }
}