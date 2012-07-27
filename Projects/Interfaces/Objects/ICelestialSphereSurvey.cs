using Interfaces.Marker;

namespace Interfaces.Objects
{
    public interface ICelestialSphereSurvey : IAggregateRoot
    {
        CelestialSphereCollection Sections { get; set; }
    }
}