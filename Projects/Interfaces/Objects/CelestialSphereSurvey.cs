using System;
using Interfaces.Marker;

namespace Interfaces.Objects
{
    public class CelestialSphereSurvey : ICelestialSphereSurvey
    {
        public CelestialSphereCollection Sections
        {
            get;
            set;
        }
    }
}
