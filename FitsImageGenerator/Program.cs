using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace FitsImageGenerator
{
    class Program
    {
        private static MongoServer _mongo;
        private static MongoDatabase _db;
        private static MongoCollection _data;

        static void Main(string[] args)
        {
            _mongo = MongoServer.Create("mongodb://127.0.0.1:27017");
            _mongo.Connect();

            _db = _mongo.GetDatabase("FITSData");

            _data = _db.GetCollection("Test");


            var conditional = Query.GT("ra", 11);
            var q2 = Query.And(conditional, Query.LT("ra", 12));
            QueryDocument query = new QueryDocument();

            int skip = 0;
            while (true)
            {
                var doc = _data.FindAllAs<BsonDocument>();
                doc.Skip = skip;
                //                doc.Limit = 50;


                var list = doc.ToList();

                if (list.Count == 0)
                    break;

                ProcessList(list);
                skip = list.Count;
                string s = "";
            }
        }

        private static void ProcessList(List<BsonDocument> list)
        {
            foreach (var doc in list)
            {
                var ra = (double)doc["ra"];
                var dec = (double)doc["dec"];

                var raTime = DateTime.FromOADate(ra);
                var decTime = DateTime.FromOADate(dec);

                Double raX = (raTime.Hour) + (raTime.Minute) + (raTime.Second) + raTime.Millisecond;
                Double decY = (decTime.Hour) + (decTime.Minute) + (decTime.Second) + decTime.Millisecond;


                double redMagnitude = 0.0;
                double blueMagnitude = 0.0;
                double greenMagnitude = 0.0;

                double irMag1 = (double)doc["ir_mag1"];
                double irMag2 = (double)doc["ir_mag2"];

                double acsMag1 = (double)doc["acs_mag1"];
                double acsMag2 = (double)doc["acs_mag2"];

                double uvMag1 = (double)doc["uv_mag1"];
                double uvMag2 = (double)doc["uv_mag2"];

                if (!double.IsNaN(irMag1))
                {
                    redMagnitude = irMag1;
                }

                if (!double.IsNaN(irMag2))
                {
                    redMagnitude = irMag2;
                }

                if (!double.IsNaN(acsMag1))
                {
                    redMagnitude = blueMagnitude = greenMagnitude= acsMag1;
                }

                if (!double.IsNaN(acsMag2))
                {
                    redMagnitude = blueMagnitude = greenMagnitude = acsMag2;
                }

                if (!double.IsNaN(uvMag1))
                {
                    blueMagnitude= uvMag1;
                }

                if (!double.IsNaN(uvMag2))
                {
                    blueMagnitude= uvMag2;
                }

                PlotPointAndMagnitude(redMagnitude, greenMagnitude, blueMagnitude, raX, decY);
            }

            b.Save("C:\\temp\\testImg.jpg");
        }


        private static Bitmap b;
        private static void PlotPointAndMagnitude(double redMagnitude, double greenMagnitude, double blueMagnitude, double raX, double decY)
        {
            if (b == null)
            {
                b = new Bitmap(1600, 1600);
                for (int i = 0; i < 1600; i++)
                {
                    for (int j = 0; j < 1600; j++)
                    {
                        b.SetPixel(i,j,Color.Black);
                    }
                }
            }

            redMagnitude = 7 * redMagnitude;
            greenMagnitude = 7 * greenMagnitude;
            blueMagnitude = 7 * blueMagnitude;

            int red, green, blue;

            red =Convert.ToInt32(redMagnitude);
            green = Convert.ToInt32(greenMagnitude);
            blue = Convert.ToInt32(blueMagnitude);


            if (red > 255)
                red = 255;

            if (green > 255)
                green = 255;

            if (blue > 255)
                blue = 255;

            b.SetPixel(Convert.ToInt32(raX), Convert.ToInt32(decY), Color.FromArgb(red, green, blue));
        }
    }
}
