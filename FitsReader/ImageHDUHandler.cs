using System;
using System.Drawing;
using nom.tam.fits;

namespace FitsReader
{
    public static class ImageHDUHandler
    {
        public static Bitmap GenerateImage(this ImageHDU hdu, int bias)
        {
            var imageArray = (Array[])hdu.Tiler.CompleteImage;

            if (imageArray.Length < 10)
            {
                var cih = new ColorImageHandler(Bias) {Bias = bias};

                return cih.ProcessColorImage(imageArray);
            }
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

//                    var colors = GetColorValues(index, index, index);

//                    var starColor = Color.FromArgb(colors[0], colors[1], colors[2]);
//                    b.SetPixel(j, i, starColor);
                }
            }
            return b;
        }

       

        public static int Bias { get; set; }

       

      
    }
}
