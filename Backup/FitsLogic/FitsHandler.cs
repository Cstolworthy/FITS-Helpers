using System.Collections.Generic;
using System.IO;
using Interfaces.FITS;
using nom.tam.fits;

namespace FitsLogic
{
    public class FitsHandler : IFitsHandler
    {
        private Fits _fits;

        public List<string> Columns
        {
            get
            {
                var hdu = _fits.GetHDU(1);
                if (hdu == null) return new List<string>();

                if (hdu is BinaryTableHDU)
                {
                    return FetchColumns(hdu as BinaryTableHDU);
                }

                return new List<string>();
            }
        }

        private List<string> FetchColumns(BinaryTableHDU binaryTableHdu)
        {
            var columns = new List<string>();
            for (int i = 0; i < binaryTableHdu.NCols; i++)
            {
                var column = binaryTableHdu.GetColumnName(i);

                columns.Add(column);
            }

            return columns;
        }

        public FitsHandler(FileInfo file)
        {
            _fits = new Fits(file);
        }



    }
}
