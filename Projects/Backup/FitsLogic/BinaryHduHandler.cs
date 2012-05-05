using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using InterfacesAndDto;
using nom.tam.fits;
using Repositories;

namespace FitsLogic
{

}



#region old
//public class BinaryHduHandler
//{
//    private string _connectionString;
//    private FitsDataRepository _repo;
//
//    public event Action<int> Progress;
//    public event Action<string> Message;
//
//    public void InvokeMessage(string message)
//    {
//        Action<string> handler = Message;
//        if (handler != null) handler(message);
//    }
//
//    public void InvokeProgress(int percentage)
//    {
//        Action<int> handler = Progress;
//        if (handler != null) handler(percentage);
//    }
//
//    public BinaryHduHandler(string mongoConnectionString)
//    {
//        _connectionString = mongoConnectionString;
//        _repo = new FitsDataRepository(mongoConnectionString);
//    }
//
//    public void Handle(BinaryTableHDU hdu, string collectionName)
//    {
//        var colNames = GetColumnNames(hdu);
//
//        var rowCount = hdu.NRows;
//
//        InvokeMessage(String.Format("There are {0} rows", rowCount));
//
//        var map = GetCollectionMap(collectionName, hdu);
//
//        _repo.SavePrimaryDocument(map);
//
//        _repo.SetDataCollectionName(collectionName);
//        double largestDec = double.MinValue;
//        double smallestDec = double.MaxValue;
//        double largestRa = double.MinValue;
//        double smallestRa = double.MaxValue;
//
//        for (int i = 0; i < rowCount; i++)
//        {
//            var row = hdu.GetRow(i);
//
//            SaveRow(colNames, row);
//            ResolveGreatestAndSmallestValues(colNames, row, "ra", ref largestRa, ref smallestRa);
//            ResolveGreatestAndSmallestValues(colNames, row, "dec", ref largestDec, ref smallestDec);
//            map.LastRecordIndex = i;
//            map.LargestDeclination = largestDec;
//            map.SmallestDeclination = smallestDec;
//            map.LargestRightAscension = largestRa;
//            map.SmallestRightAcesnion = smallestRa;
//            _repo.SavePrimaryDocument(map);
//            if (i % 1000 == 0)
//                ReportProgress(rowCount, i, rowCount);
//        }
//
//        map.Status = CollectionStatus.CreatingIndexes;
//
//        _repo.SavePrimaryDocument(map);
//
//        CreateIndexes(colNames);
//
//        map.Status = CollectionStatus.ReadyForImageHandler;
//
//        _repo.SavePrimaryDocument(map);
//    }
//
//    private void ResolveGreatestAndSmallestValues(List<string> colNames, Array row, string colName, ref double largest, ref double smallest)
//    {
//        int raColumn = -1;
//
//        for (int i = 0; i < colNames.Count; i++)
//        {
//            if (colNames[i].ToLower().StartsWith(colName.ToLower()))
//            {
//                raColumn = i;
//                break;
//            }
//        }
//
//        if (raColumn > -1)
//        {
//            var theVal = row.GetValue(raColumn);
//            double rightAscension;
//            if (double.TryParse(theVal.ToString(), out rightAscension))
//            {
//                if (rightAscension > largest)
//                    largest = rightAscension;
//
//                if (rightAscension < smallest)
//                    smallest = rightAscension;
//            }
//        }
//    }
//
//    private void CreateIndexes(List<string> colNames)
//    {
//        foreach (var colName in colNames)
//        {
//            _repo.CreateIndex(colName);
//        }
//
//    }
//
//    private static CollectionMap GetCollectionMap(string collectionName, BinaryTableHDU hdu)
//    {
//        var map = new CollectionMap
//        {
//            Author = hdu.Author,
//            BitPix = hdu.BitPix,
//            BScale = hdu.BScale,
//            BUnit = hdu.BUnit,
//            BZero = hdu.BZero,
//            CollectionName = collectionName,
//            CreationDate = hdu.CreationDate,
//            Epoch = hdu.Epoch,
//            Equinox = hdu.Equinox,
//            FileOffset = hdu.FileOffset,
//            GroupCount = hdu.GroupCount,
//            InsertDate = DateTime.UtcNow,
//            Instrument = hdu.Instrument,
//            MaximumValue = hdu.MaximumValue,
//            MinimumValue = hdu.MinimumValue,
//            Object = hdu.Object,
//            ObservationDate = hdu.ObservationDate,
//            Observer = hdu.Observer,
//            Origin = hdu.Origin,
//            ParameterCount = hdu.ParameterCount,
//            Reference = hdu.Reference,
//            Rewriteable = hdu.Rewriteable,
//            Size = hdu.Size,
//            Status = CollectionStatus.Inserting,
//            Telescope = hdu.Telescope
//        };
//
//        return map;
//    }
//
//    private string SaveIdsToLinker(List<string> idNames)
//    {
//        return _repo.SaveLinker(idNames);
//    }
//
//    private void ReportProgress(int rowCount, int i, int count)
//    {
//        var cnt = (Convert.ToDecimal(i) / Convert.ToDecimal(rowCount)) * 100;
//        InvokeProgress(Convert.ToInt32(cnt));
//        InvokeMessage(string.Format("Processed Row: {0} of {1}", i, count));
//    }
//
//    private string SaveRow(List<string> colNames, Array row)
//    {
//        var values = new Dictionary<string, string>();
//
//        for (int i = 0; i < colNames.Count; i++)
//        {
//            var val = row.GetValue(i);
//
//            if (val != null)
//                values.Add(colNames[i], val.ToString());
//        }
//
//        return _repo.SaveRow(values);
//    }
//
//    public List<String> GetColumnNames(BinaryTableHDU hdu)
//    {
//        var row = hdu.GetRow(0);
//
//        return row.Cast<object>().Select((t, i) => hdu.GetColumnName(i)).ToList();
//    }
//}
#endregion old