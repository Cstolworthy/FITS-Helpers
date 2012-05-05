using System;
using System.Drawing;
using Utilities;

namespace FitsReader
{
    public class ColorImageHandler
    {
        public int Bias { get; set; }

        public ColorImageHandler(int bias)
        {
            Bias = bias;
        }

        public Bitmap ProcessColorImage(Array[] imageArray)
        {
            var redArray = (Array[])imageArray.GetValue(0);
            var greenArray = (Array[])imageArray.GetValue(1);
            var blueArray = (Array[])imageArray.GetValue(2);

            int height = redArray.Length;
            int width = redArray[0].Length;

            var b = new Bitmap(width, height);

            ImageHduUtilities.IterateRows(redArray, greenArray, blueArray, b, Bias);

            b.RotateFlip(RotateFlipType.RotateNoneFlipY);

            return b;
        }

     

  
    }
}
