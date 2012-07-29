using Interfaces;
using Interfaces.Collections;

namespace Core.Objects
{
    public class CelestialSphereSurvey : ICelestialSphereSurvey
    {
        public object ObjectId { get; set; }
        
        public CelestialSphereCollection Sections { get; set; }

        public string SectionsCollectionName{get; set; }
        
    }
}
