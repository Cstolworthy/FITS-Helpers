using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;
using nom.tam.fits;

namespace FitsReader
{
    public class FitsReader
    {
        public event Action ImageReady;

        public void InvokeImageReady()
        {
            Action handler = ImageReady;
            if (handler != null) handler();
        }

        private MongoServer _mongo;
        private MongoDatabase _db;
        private MongoCollection _collection;
        public Bitmap Image { get; set; }

        public int Bias { get; set; }

        public FitsReader()
        {
            _mongo = MongoServer.Create("mongodb://127.0.0.1:27017");
            _mongo.Connect();

            _db = _mongo.GetDatabase("test");

            _collection = _db.GetCollection("test");
        }


        public void Parse(string fileName)
        {
            var f = new Fits(fileName);
            
            BasicHDU curHdu = f.GetHDU(0);

            int i = 1;
            do
            {
                if (curHdu is BinaryTableHDU)
                    (curHdu as BinaryTableHDU).ConvertAndSave(_collection);
                else if (curHdu is ImageHDU)
                {
                    if ((curHdu as ImageHDU).Tiler != null)
                    {
                        Image = (curHdu as ImageHDU).GenerateImage(Bias);
                        InvokeImageReady();
                    }
                }
                else
                    Debugger.Break();

                curHdu = FetchHduSafely(f,ref i);
             
            } while (curHdu != null);
        }

        private BasicHDU FetchHduSafely(Fits fits, ref int i)
        {
            int count = 0;

            while (true)
            {
                try
                {
                    var hdu = fits.GetHDU(i);
                    i++;
                    return hdu;
                }
                catch (Exception)
                {
                    i++;
                    count++;

                    if (count >= 10)
                        return null;
                }
            }

        }


    }
}
