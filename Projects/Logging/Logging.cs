using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Core;

namespace Logging
{
    public class Logging
    {
        private static Logging _logger;
        public static Logging Logger
        {
            get
            {
                lock (typeof(Logging))
                    return _logger ?? (_logger = new Logging());
            }
        }

        public static ILog GetLogger(Type t)
        {
            return LogManager.GetLogger(t);
        }

        public static ILog GetLogger(string repository, Type t)
        {
            return LogManager.GetLogger(repository, t);
        }

        public static ILog GetLogger(string repository, string name)
        {
            return LogManager.GetLogger(repository, name);
        }

        public static ILog GetLogger(string name)
        {
            return LogManager.GetLogger(name);
        }

        public Logging()
        {
            var assembly = Assembly.GetAssembly(typeof(Logging));
            var fi = new FileInfo(Path.Combine(assembly.Location, "log.config"));
            log4net.Config.XmlConfigurator.Configure(fi);

        }
    }
}
