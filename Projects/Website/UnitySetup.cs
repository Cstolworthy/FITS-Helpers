using System.Configuration;
using DataAccess;
using FitsLogic;
using Interfaces.DataAccess;
using Interfaces.FITS;
using Mappers;
using Microsoft.Practices.Unity;

namespace Website
{
    public static class UnitySetup
    {
        private static IUnityContainer _container;

        public static void SetupDependencies(IUnityContainer container)
        {
            _container = container;
            _container.RegisterType<IFitsMapper, FitsMapper>();
            _container.RegisterType<IFitsFileAccess, FitsFileSystemAccess>();
            InjectionMember im = new InjectionConstructor(ConfigurationManager.ConnectionStrings["MongoConnection"].ConnectionString);
            _container.RegisterType<IFitsImporterDataAccess, FitsImporterDataAccess>("", im);

        }
    }
}