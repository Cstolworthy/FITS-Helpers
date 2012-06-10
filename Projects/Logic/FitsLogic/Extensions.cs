using System.Collections.Generic;
using nom.tam.fits;

namespace FitsLogic
{
    public static class Extensions
    {
        public static IEnumerable<KeyValuePair<int, string>> GetColumnNames(this BinaryTableHDU curHdu)
        {
            var firstRow = curHdu.GetRow(0);

            int i = 0;
            foreach (var colVal in firstRow)
            {
                var colName = curHdu.GetColumnName(i);
                yield return new KeyValuePair<int, string>(i, colName);

                i++;
            }
        }
    }
}
