using TestAutomation.Core.Drivers;
using TestAutomation.Core.Utilities.Helpers;

namespace TestAutomation.Core.Managers
{
    public class ConfigManager
    {
        public static DriverType CurrentDriverType => DriverTypeHelper.GetDriverTypeByString(DriverType);

        public static string BrowserVersion => ConfigurationHelper.Configuration.AppSettings.BaseEndpoint;
        public static string DriverType => ConfigurationHelper.Configuration.AppSettings.DriverType;
    }
}
