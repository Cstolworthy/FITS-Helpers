using System.Web.Configuration;
using FitsLogic;
using Interfaces.FITS;
using Interfaces.Website;
using Interfaces.Website.Model;
using Microsoft.Practices.Unity;
using MongoDB.Driver;
using Objects.Website;
using Objects.Website.Model;

namespace Website
{
    public static class UnitySetup
    {
        private static MongoServer _mongo;

        public static void SetupDependencies(IUnityContainer container)
        {

            var mongoConnString = WebConfigurationManager.ConnectionStrings["mongodb"].ConnectionString;
            _mongo = MongoServer.Create(mongoConnString);
            _mongo.Connect();

            var uploadPath = WebConfigurationManager.AppSettings["UploadedFilePath"];
            var processPath = WebConfigurationManager.AppSettings["ProcessedFilePath"];
            container.RegisterType<IUploadedFiles, UploadedFiles>(new InjectionConstructor(uploadPath,processPath));
            container.RegisterType<IProcessModel, ProcessModel>();
            container.RegisterType<IDesignateModel, DesignateModel>();
            container.RegisterType<IFitsHandler, FitsHandler>();
        }

        public static void Cleanup()
        {
            _mongo.Disconnect();
            _mongo = null;
        }
    }
}