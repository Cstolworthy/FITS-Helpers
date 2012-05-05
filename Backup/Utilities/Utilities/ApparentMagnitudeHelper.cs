using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public class ApparentMagnitudeHelper
    {
        private static Dictionary<int, int> _pixelBrightness;
        public static Dictionary<int, int> PixelBrightnessMapping
        {
            get
            {
                lock (_pixelBrightness)
                {
                    if (_pixelBrightness == null)
                        PopulatePixels();

                    return _pixelBrightness;
                }
            }
        }

        private static void PopulatePixels()
        {
            _pixelBrightness = new Dictionary<int, int>();
            double currentVal = 1;
            int start = 36;
            for (int i = 0; i <= 74; i++)
            {
                int val = Convert.ToInt32(currentVal);
                if (val > 255)
                    val = 255;
                _pixelBrightness.Add(start, val);
                start--;
                currentVal = currentVal + 3.5;
            }
        }

        public static int GetPixelBrightnessForMagnitude(double magnitude)
        {
            var brightness = PixelBrightnessMapping;

            var cast = Math.Floor(magnitude);

            var theInt = Convert.ToInt32(cast);

            return brightness.Where(b => b.Key == theInt).Select(k => k.Value).FirstOrDefault();
        }
    }
}
