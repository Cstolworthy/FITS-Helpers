using System.Web.Configuration;
using Microsoft.Practices.Unity;

namespace AstronomySite
{
    public static class UnitySetup
    {
//        private static MongoServer _mongo;

        public static void SetupDependencies(IUnityContainer container)
        {

            var mongoConnString = WebConfigurationManager.ConnectionStrings["mongodb"].ConnectionString;
//            _mongo = MongoServer.Create(mongoConnString);
//            _mongo.Connect();

            var uploadPath = WebConfigurationManager.AppSettings["UploadedFilePath"];
            var processPath = WebConfigurationManager.AppSettings["ProcessedFilePath"];
//            container.RegisterType<IUploadedFiles, UploadedFiles>(new InjectionConstructor(uploadPath, processPath));
//            container.RegisterType<IProcessModel, ProcessModel>();
//            container.RegisterType<IDesignateModel, DesignateModel>();
//            container.RegisterType<IFitsHandler, FitsHandler>();
        }

        public static void Cleanup()
        {
//            _mongo.Disconnect();
//            _mongo = null;
        }
    }
}