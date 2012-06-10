using System.Collections.Generic;
using nom.tam.fits;

namespace Interfaces.FITS
{
    public interface IFitsRepository 
    {
        void CreateNewImport(BasicHDU hdu);
        IEnumerable<IFileImportOptions> GetFilesWaitingImport();
    }
}
