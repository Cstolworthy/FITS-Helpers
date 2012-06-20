using System;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using BusinessLogic.Factories;
using Castle.Windsor;
using Interfaces.Services;

namespace HybridService
{
    public abstract class AbstractProgram
    {
        static string applicationName = System.Diagnostics.Process.GetCurrentProcess().ProcessName.Replace(".vshost", "");
        static string applicationPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        private static IWindsorContainer container;

        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>        
        public static void BaseMain()
        {
            container = WindsorFactory.CreateContainer();

          

            if (Environment.CommandLine.Contains("-service"))
            {
                ServiceWrapper wrapper = container.Resolve<ServiceWrapper>();
                if (ServiceCheck(true, wrapper.ApplicationTitle) == false)
                {
                    ServiceController controller = new ServiceController(applicationName);
                    controller.Start();
                    return;
                }

                ServiceBase[] services = new ServiceBase[] { wrapper };
                ServiceBase.Run(services);
            }
            else if (Environment.CommandLine.Contains("-noservice"))
            {
                ServiceWrapper wrapper = container.Resolve<ServiceWrapper>();
                if (ServiceCheck(false, wrapper.ApplicationTitle))
                {
                    ServiceController controller = new ServiceController(applicationName);
                    if (controller.Status == ServiceControllerStatus.Running) controller.Stop();
                    ServiceInstaller.UnInstallService(applicationName);
                }
            }
            else
            {
                IConsoleApplication application = container.Resolve<IConsoleApplication>();
            }
        }

        static bool ServiceCheck(bool autoInstall, string title)
        {
            bool installed = false;

            ServiceController[] controllers = ServiceController.GetServices();
            foreach (ServiceController con in controllers)
            {
                if (con.ServiceName == applicationName)
                {
                    installed = true;
                    break;
                }
            }

            if (installed) return true;

            if (autoInstall)
            {
                ServiceInstaller.InstallService("\"" + applicationPath + "\\" + applicationName + ".exe\" -service", applicationName, title, true, false);
            }

            return false;
        }
    }
}
