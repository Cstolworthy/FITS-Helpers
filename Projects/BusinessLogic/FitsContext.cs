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
    public class FitsContext : IFitsContext
    {
        private readonly IFitsImporterRepository _importerRepository;

        public FitsContext(IFitsImporterRepository importerRepository)
        {
            _importerRepository = importerRepository;
        }

        public IEnumerable<IFileImportRequest> GetImportRequests()
        {
            return _importerRepository.GetImportRequests();
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
 