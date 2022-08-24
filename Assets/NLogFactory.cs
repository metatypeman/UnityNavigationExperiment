using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assets
{
    public static class NLogFactory
    {
        private readonly static object _lockObj = new object();

        private static Logger _logger;

        public static Logger GetLogger()
        {
            lock(_lockObj)
            {
                if(_logger == null)
                {
                    var logFile = Path.Combine(@"c:\Users\Acer\", $"MyLog.log");

                    var config = new NLog.Config.LoggingConfiguration();

                    var logfile = new NLog.Targets.FileTarget("logfile") { FileName = logFile, Layout = "${message}" };
                    config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

                    var logFactory = new LogFactory(config);

                    _logger = logFactory.GetCurrentClassLogger();
                }

                return _logger;
            }
        }
    }
}
