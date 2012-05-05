using System;
using System.IO;
using log4net;
using log4net.Config;

namespace Logging
{
    public class Logging
    {
        private static bool _configured;

        public static ILog GetLogger(Type t)
        {
            Configure();

            return LogManager.GetLogger(t);
        }

        private static object _lock = new object();
        private static void Configure()
        {
            lock (_lock)
                if (!_configured)
                {
                    var loc = typeof(Logging).Assembly.Location;

                    loc = Path.GetDirectoryName(loc);
                    loc = Path.Combine(loc, "LoggingConfig.cfg");
                    XmlConfigurator.Configure(new System.IO.FileInfo(loc));
                    _configured = true;
                }
        }

        public static ILog GetLogger(string repo, Type t)
        {
            Configure();

            return LogManager.GetLogger(repo, t);
        }

        public static ILog GetLogger(string repo, string name)
        {
            Configure();

            return LogManager.GetLogger(repo, name);
        }

        public static ILog GetLogger(string name)
        {
            Configure();

            return LogManager.GetLogger(name);
        }
    }
}
