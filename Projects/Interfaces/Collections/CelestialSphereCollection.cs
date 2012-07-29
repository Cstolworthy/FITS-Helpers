using System;
using System.Collections.Generic;

namespace Interfaces.Collections
{
    public class CelestialSphereCollection : List<ICelestialSphereSection>
    {
        public String CollectionName {get; set; }
    }
}