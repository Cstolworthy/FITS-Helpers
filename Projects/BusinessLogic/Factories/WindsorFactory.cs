using System;
using System.IO;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace BusinessLogic.Factories
{
    public class WindsorFactory
    {
        private static WindsorContainer _container;

        internal WindsorFactory()
        {
            
        }

        static private string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;

                var uri = new UriBuilder(codeBase);

                var path = Uri.UnescapeDataString(uri.Path);

                return Path.GetDirectoryName(path);
            }
        }

        public static IWindsorContainer CreateContainer()
        {
            lock (typeof(WindsorContainer))
            {
                if (_container == null)
                {
                    _container = new WindsorContainer();
                    _container.Install(FromAssembly.This());
                    _container.Install(FromAssembly.InDirectory(new AssemblyFilter(AssemblyDirectory)));
                }
            }
            return _container;
            
        }
    }
}
