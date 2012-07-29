using System.Collections.Generic;

namespace Interfaces.Collections
{
    public class ColorIntensityCollection : List<KeyValuePair<string, double>>
    {
        public void Add(string name, double intensity)
        {
            Add(new KeyValuePair<string, double>(name, intensity));
        }
    }
}