using System;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Spark.Web.Mvc;

namespace AstronomySite
{


    public class MvcApplication : System.Web.HttpApplication, IContainerAccessor
    {
        #region Members

        private static IUnityContainer _container;

        #endregion

        #region Properties
        /// <summary>
        /// The Unity container for the current application
        /// </summary>
        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
        }

        /// <summary>
        /// Returns the Unity container of the application 
        /// </summary>
        IUnityContainer IContainerAccessor.Container
        {
            get { return Container; }
        }

        #endregion Properties

        private static void InitContainer()
        {
            if (_container == null)
            {
                _container = new UnityContainer();
                UnitySetup.SetupDependencies(_container);
            }

            // Register the relevant types for the 
            // container here through classes or configuration
            //            _container.RegisterType<IMessageService, MessageService>();
        }

        private static void CleanUp()
        {
            if (Container != null)
            {
                Container.Dispose();
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {
            UnitySetup.Cleanup();
            CleanUp();
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //            routes.Add(new ServiceRoute("documents", new WebServiceHostFactory(), typeof(DocumentsResource)));
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute("404-PageNotFound","{*url}", new { controller = "StaticContent", action = "PageNotFound" });
        }

        protected void Application_Start()
        {
            InitContainer();
            ViewEngines.Engines.Add(new SparkViewFactory());
            AreaRegistration.RegisterAllAreas();
            //            ViewEngines.Engines.Add(new SparkViewFactory());
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(typeof(UnityControllerFactory));
        }
    }
}