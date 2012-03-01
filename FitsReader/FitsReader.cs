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
        private MongoServer _mongo;
        private MongoDatabase _db;
        private MongoCollection _collection;

        public FitsReader()
        {
            _mongo = MongoServer.Create("mongodb://127.0.0.1:27017");
            _mongo.Connect();

            _db = _mongo.GetDatabase("test");

            _collection = _db.GetCollection("test");
        }


        public void Begin()
        {
//            Fits f = new Fits("c:\\temp\\GalaxyZoo1_DR_table2.fits");
            Fits f = new Fits("c:\\fits\\color_hst_05210_02_wfpc2_f656n_f255w_wf_sci.fits");
            
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
                        var d = (curHdu as ImageHDU).GenerateImage();

                        d.Save("c:\\temp\\test.jpg");

                    }
//                    MemoryStream ms = new MemoryStream();
//                    ms.Write(d,0,d.Length);
//                    ms.Position = 0;
//                    StreamReader sr = new StreamReader(ms);
//                    sr.ReadToEnd();


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
