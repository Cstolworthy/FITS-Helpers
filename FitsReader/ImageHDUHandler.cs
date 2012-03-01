using System;
using System.Drawing;
using nom.tam.fits;

namespace FitsReader
{
    public static class ImageHDUHandler
    {
        //         BitmapSource image = BitmapSource.Create(

        public static Bitmap GenerateImage(this ImageHDU hdu)
        {

            var imageArray = (Array[])hdu.Tiler.CompleteImage;

            if (imageArray.Length < 10)
                return ProcessColorImage(imageArray);
            else
                return ProcessGreyscaleImage(imageArray);
        }

        private static Bitmap ProcessGreyscaleImage(Array[] imageArray)
        {
            int height = imageArray.Length;
            int width = imageArray[0].Length;

            Bitmap b = new Bitmap(width, height);
            float largest = 0;
            for (int i = 0; i < imageArray.Length; i++)
            {
                var currentRow = imageArray[i];
                for (int j = 0; j < width; j++)
                {

                    var index = (float)currentRow.GetValue(j);

                    var colors = GetColorValues(index, index, index);

                    var starColor = Color.FromArgb(colors[0], colors[1], colors[2]);
                    b.SetPixel(j, i, starColor);
                }
            }
            return b;
        }

        private static int[] GetColorValues(float redIndex, float greenIndex, float blueIndex)
        {
            int bias = 55;

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

        private static Bitmap ProcessColorImage(Array[] imageArray)
        {
            var redArray = (Array[])imageArray.GetValue(0);
            var greenArray = (Array[])imageArray.GetValue(1);
            var blueArray = (Array[])imageArray.GetValue(2);

            int height = redArray.Length;
            int width = redArray[0].Length;

            Bitmap b = new Bitmap(width, height);

            for (int i = 0; i < height; i++)
            {
                var currentRedRow = redArray[i];
                var currentGreenRow = greenArray[i];
                var currentBlueRow = blueArray[i];

                for (int j = 0; j < width; j++)
                {

                    var redIndex = (float)currentRedRow.GetValue(j);
                    var greenIndex = (float)currentGreenRow.GetValue(j);
                    var blueIndex = (float)currentBlueRow.GetValue(j);

                    var colors = GetColorValues(redIndex, greenIndex, blueIndex);

                    var starColor = Color.FromArgb(colors[0], colors[1], colors[2]);
                    b.SetPixel(j, i, starColor);
                }
            }
            b.RotateFlip(RotateFlipType.RotateNoneFlipY);
            return b;
        }
    }
}
