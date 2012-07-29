using System;
using System.IO;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Core.Exceptions;

namespace Core.Factories
{
    public class ServiceFactory
    {
        private static readonly IWindsorContainer _container = new WindsorContainer();
        private static readonly object InstallerLockObject = new object();
        private static bool _installed = false;

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

        private static void Install()
        {
            if (_installed)
                return;

            _installed = true;

            _container.Install(FromAssembly.This());
            _container.Install(FromAssembly.InDirectory(new AssemblyFilter(AssemblyDirectory)));
        }

        public static void Initialize()
        {
            lock (InstallerLockObject)
            {
                Install();
            }
        }

        public static T Create<T>() where T : class
        {
            Initialize();

            var returnObject = _container.Resolve<T>();

            if (returnObject == null)
            {
                throw new UnregisteredObjectTypeException(string.Format("Failed to create an object of type '{0}'.  Make sure the object is registered properly.", typeof(T).FullName));
            }
            return returnObject;
        }

        public static T[] ResolveAll<T>()
        {
            Initialize();

            return _container.ResolveAll<T>();
        }
    }
}