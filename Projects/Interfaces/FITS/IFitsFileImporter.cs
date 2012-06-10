using Interfaces.DTO;

namespace Interfaces.FITS
{
    public interface IFitsFileImporter
    {
        void ProcessIndividualFile(IFileImportOptions fileOptions);
    }
}
