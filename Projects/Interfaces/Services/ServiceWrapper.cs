using System.ServiceProcess;
using Interfaces.Marker;

namespace Interfaces.Services
{
    public abstract class ServiceWrapper : ServiceBase, IService
    {
        public abstract string ApplicationTitle { get; }
    }
}
