using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Interfaces;
using Microsoft.Practices.Unity;

namespace Website
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication, IContainerAccessor
    {
        private static IUnityContainer _container;

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

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

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        protected void Application_Start()
        {
            InitContainer();
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            BundleTable.Bundles.RegisterTemplateBundles();
            ControllerBuilder.Current.SetControllerFactory(typeof(UnityControllerFactory));
        }

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
    }
}