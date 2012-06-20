using System.Collections.Generic;
using System.IO;
using System.Linq;
using FitsLogic;
using Interfaces.DataAccess;
using Interfaces.DTO;
using Interfaces.FITS;
using nom.tam.fits;

namespace BusinessLogic
{
    public class FitsManager : IFitsManager
    {
        private readonly IFitsImporterDataAccess _importerDataAccess;

        public FitsManager(IFitsImporterDataAccess importerDataAccess)
        {
            _importerDataAccess = importerDataAccess;
        }

        public IEnumerable<IFileImportRequest> GetImportRequests()
        {
            return _importerDataAccess.GetImportRequests();
        }

        public IEnumerable<string> GetColumnHeaders(FileInfo file)
        {
            Fits f = new Fits(file);

            BasicHDU hdu;
            while((hdu = f.ReadHDU()) != null)
            {
                if(!(hdu is BinaryTableHDU))
                    continue;


                BinaryTableHDU tableHdu = hdu as BinaryTableHDU;

                return tableHdu.GetColumnNames().Select(clm=>clm.Value).ToList();
            }

            return null;
        }
    }
}
 