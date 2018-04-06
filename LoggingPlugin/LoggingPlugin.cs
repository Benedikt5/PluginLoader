using System;
using System.ComponentModel;
using NLog;
using PluginApi;

namespace LoggingPlugin
{
    [DisplayName("logging")]
    public class LoggingPlugin : IPlugin
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        public void DoSeriousBusiness(string msg)
        {
            Console.WriteLine("logging message to log...");
            _log.Info(msg);
        }
    }
}
