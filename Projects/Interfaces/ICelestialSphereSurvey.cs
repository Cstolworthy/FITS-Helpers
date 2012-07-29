using Interfaces.Collections;
using Interfaces.Marker;

namespace Interfaces
{
    public interface ICelestialSphereSurvey : IAggregateRoot
    {
        
        object ObjectId { get; set; }
        CelestialSphereCollection Sections { get; set; }
        string SectionsCollectionName { get; set; }
    }
}