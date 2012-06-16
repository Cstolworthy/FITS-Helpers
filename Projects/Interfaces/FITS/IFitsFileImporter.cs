using Interfaces.DTO;
using Interfaces.Marker;

namespace Interfaces.FITS
{
    public interface IFitsFileImporter : IService
    {
        void ProcessIndividualFile(IFileImportOptions fileOptions);
    }
}
