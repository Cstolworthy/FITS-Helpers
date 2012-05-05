using System.ServiceModel;

namespace Interfaces.Website.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFITSUpload" in both code and config file together.
    [ServiceContract]
    public interface IFitsUpload
    {
        [OperationContract]
        void TransmitFile();
    }
}
