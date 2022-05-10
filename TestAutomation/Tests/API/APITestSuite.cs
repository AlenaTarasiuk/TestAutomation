using NLog;
using NLog.Config;
using NLog.Targets;

namespace TestAutomation.Tests.API
{
    public class APITestSuite
    {
        public APITestSuite()
        {
            var config = new LoggingConfiguration();

            config.AddRule(LogLevel.Info, LogLevel.Fatal, new ConsoleTarget("logconsole"));

            LogManager.Configuration = config;
        }

        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    }
}
