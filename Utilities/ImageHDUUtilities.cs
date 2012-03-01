using System;
using System.Drawing;

namespace Utilities
{
    public class ImageHduUtilities
    {
        public static void IterateRows(Array[] redArray, Array[] greenArray, Array[] blueArray, Bitmap b, int bias)
        {
            for (int i = 0; i < redArray.Length; i++)
            {
                var currentRedRow = redArray[i];
                var currentGreenRow = greenArray[i];
                var currentBlueRow = blueArray[i];

                IterateColumns(i, currentRedRow, currentGreenRow, currentBlueRow, b, bias);
            }
        }

        private static void IterateColumns(int y, Array currentRedRow, Array currentGreenRow, Array currentBlueRow, Bitmap b, int bias)
        {
            for (int j = 0; j < currentRedRow.Length; j++)
            {
                var redIndex = (float)currentRedRow.GetValue(j);
                var greenIndex = (float)currentGreenRow.GetValue(j);
                var blueIndex = (float)currentBlueRow.GetValue(j);

                var colors = GetColorValues(redIndex, greenIndex, blueIndex, bias);

                var starColor = Color.FromArgb(colors[0], colors[1], colors[2]);
                b.SetPixel(j, y, starColor);
            }
        }

        private static int[] GetColorValues(float redIndex, float greenIndex, float blueIndex, int bias)
        {
            if (bias == 0)
                bias = 1;

            int red = 0,
                green = 0,
                blue = 0;

            var redcolorindex = 255 * redIndex;
            var bluecolorindex = 255 * blueIndex;
            var greencolorindex = 255 * greenIndex;

            if (redIndex > 0 && redIndex < 1)
                redcolorindex = redcolorindex * bias;

            if (blueIndex > 0 && blueIndex < 1)
                bluecolorindex = bluecolorindex * bias;

            if (greenIndex > 0 && greenIndex < 1)
                greencolorindex = greencolorindex * bias;

            red = Convert.ToInt32(redcolorindex);
            green = Convert.ToInt32(greencolorindex);
            blue = Convert.ToInt32(bluecolorindex);

            if (red > 255)
                red = 255;

            if (red < 0)
                red = 0;

            if (green > 255)
                green = 255;

            if (green < 0)
                green = 0;

            if (blue > 255)
                blue = 255;

            if (blue < 0)
                blue = 0;

            return new int[] { red, green, blue };
        }
    }
}
