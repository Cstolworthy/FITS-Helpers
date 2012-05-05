using System;
using System.Drawing;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Repositories;

namespace FitsImageGenerator
{
    class Program
    {
        private static MongoServer _mongo;
        private static MongoDatabase _db;
        private static MongoCollection _data;

        static void Main(string[] args)
        {
            var fdr = new FitsDataRepository("mongodb://127.0.0.1:27017");

            var documents = fdr.GetPrimaryDocuments();


            foreach (var collectionMap in documents)
            {
                var decRange = collectionMap.LargestDeclination - collectionMap.SmallestDeclination;
                var raRange = collectionMap.LargestRightAscension - collectionMap.SmallestRightAcesnion;
                var width = Convert.ToInt32(raRange * 10000);
                var height = Convert.ToInt32(decRange * 10000);

                Bitmap b = new Bitmap(width,height);
                //equator == 0, north pole = 90, south pole = -90

                var count = fdr.GetCollectionCount(collectionMap.CollectionName,12);
                
                for (int i = 0; i < count; i += 100)
                {
                    var rows =  fdr.Find(collectionMap.CollectionName,i, 100, 12);
                    
                    foreach (var row in rows)
                    {
                        var dec = row["dec"].ToDouble();
                        var ra = row["ra"].ToDouble();

                        int x = 0;
                        int y = 0;

                        if(collectionMap.LargestRightAscension == ra)
                        {
                            x = width;
                        }
                        else
                        {
                            if(collectionMap.SmallestRightAcesnion != ra)
                            {
                                var units = collectionMap.LargestRightAscension - ra;
                                units = units*10000;
                                int intUnits = Convert.ToInt32(units);
                                x = intUnits;
                            }
                        }

                        if(collectionMap.LargestDeclination == dec)
                        {
                            y = height;
                        }
                        else
                        {
                            if (collectionMap.SmallestDeclination != dec)
                            {
                                var units = collectionMap.LargestDeclination - dec;
                                units = units * 10000;
                                int intUnits = Convert.ToInt32(units);
                                y = intUnits;
                            }
                        }

                        var acs = row["acs_mag1"].ToDouble();
                        var uv = row["uv_mag1"].ToDouble();
                        var ir = row["ir_mag1"].ToDouble();
                        Color starColor = SystemColors.ActiveBorder;

                        if (!Double.IsNaN(acs))
                            starColor = Color.Green;

                        if (!Double.IsNaN(uv))
                            starColor = Color.Purple;

                        if (!Double.IsNaN(ir))
                            starColor = Color.Red;
                        b.SetPixel(x,y, starColor);
                       
                    }
                }
                b.Save("C:\\temp\\test.jpg");
            }


        }
    }

}
