using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using nom.tam.fits;

namespace FitsReader
{
    public static class BinaryHduHandler
    {

        public static void ConvertAndSave(this BinaryTableHDU hdu, MongoCollection collection)
        {
            ReadIndividuallyAndSave(hdu, collection);

        }

        private static void ReadIndividuallyAndSave(BinaryTableHDU hdu, MongoCollection collection)
        {
            var columns = PopulateColumnNames(hdu);


            for (int i = 0; i < hdu.NRows; i++)
            {
                var curRow = hdu.GetRow(i);
                var doc = new BsonDocument();

                for (int j = 0; j < columns.Count; j++)
                {
                    var val = curRow.GetValue(j);
                    var t = val.GetType();

                    BsonType curType;
                    if (!Enum.TryParse(t.Name, true, out curType))
                    {
                        if (val is Int16)
                        {
                            curType = BsonType.Int32;
                            val = Convert.ToInt32(val);
                        }

                    }

                    switch (curType)
                    {
                        case BsonType.Int64:
                            doc[columns[j]] = (Int64)val;
                            break;
                        case BsonType.Int32:
                            doc[columns[j]] = (Int32)val;
                            break;
                        case BsonType.Double:
                            doc[columns[j]] = (Double)val;
                            break;
                        case BsonType.Boolean:
                            doc[columns[j]] = (Boolean)val;
                            break;
                        case BsonType.String:
                            doc[columns[j]] = (String)val;
                            break;
                        default:
                            doc[columns[j]] = val.ToString();
                            break;

                    }

                }
                collection.Save(doc);
                


            }



        }

        private static Dictionary<int, string> PopulateColumnNames(BinaryTableHDU hdu)
        {
            var firstRow = hdu.GetRow(0);

            int i = 0;
            var columns = new Dictionary<int, string>();
            foreach (var colVal in firstRow)
            {
                var colName = hdu.GetColumnName(i);
                columns.Add(i, colName);
                i++;
            }

            return columns;
        }
    }
}
