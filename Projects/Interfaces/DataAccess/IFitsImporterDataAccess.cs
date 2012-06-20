using System.Collections.Generic;
using Interfaces.DTO;
using Interfaces.Marker;

namespace Interfaces.DataAccess
{
    public interface IFitsImporterDataAccess : IDataAccess
    {
        void Save(IFileImportRequest fileRequest);
        IEnumerable<IFileImportRequest> GetImportRequests();
    }
}