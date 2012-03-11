using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using nom.tam.fits;
using Repositories;

namespace FitsLogic
{
    public class BinaryHduHandler
    {
        private string _connectionString;
        private FitsDataRepository _repo;

        public event Action<int> Progress;
        public event Action<string> Message;

        public void InvokeMessage(string message)
        {
            Action<string> handler = Message;
            if (handler != null) handler(message);
        }

        public void InvokeProgress(int percentage)
        {
            Action<int> handler = Progress;
            if (handler != null) handler(percentage);
        }

        public BinaryHduHandler(string mongoConnectionString)
        {
            _connectionString = mongoConnectionString;
            _repo = new FitsDataRepository(mongoConnectionString);
        }

        public void Handle(BinaryTableHDU hdu)
        {
            var colNames = GetColumnNames(hdu);
            var linkIds = new List<string>();
            var idNames = new List<string>();

            var rowCount = hdu.NRows;
            InvokeMessage(String.Format("There are {0} rows", rowCount));
            for (int i = 0; i < rowCount; i++)
            {
                var row = hdu.GetRow(i);

                var id = SaveRow(colNames, row);

                idNames.Add(id);

                if (idNames.Count > 100000)
                {
                    var linkid = SaveIdsToLinker(idNames);
                    linkIds.Add(linkid);
                    idNames.Clear();
                    Thread.Sleep(100);
                }

                if (i % 1000 == 0)
                    ReportProgress(rowCount, i);
            }
            
            _repo.SavePrimaryDocument(linkIds);
        }

        private string SaveIdsToLinker(List<string> idNames)
        {
            return _repo.SaveLinker(idNames);
        }

        private void ReportProgress(int rowCount, int i)
        {
            var cnt = (Convert.ToDecimal(i) / Convert.ToDecimal(rowCount)) * 100;
            InvokeProgress(Convert.ToInt32(cnt));
            InvokeMessage(string.Format("Processed Row: {0}", i));
        }

        private string SaveRow(List<string> colNames, Array row)
        {
            var values = new Dictionary<string, string>();

            for (int i = 0; i < colNames.Count; i++)
            {
                var val = row.GetValue(i);

                if (val != null)
                    values.Add(colNames[i], val.ToString());
            }

            return _repo.SaveRow(values);
        }

        public List<String> GetColumnNames(BinaryTableHDU hdu)
        {
            var row = hdu.GetRow(0);

            return row.Cast<object>().Select((t, i) => hdu.GetColumnName(i)).ToList();
        }
    }
}
