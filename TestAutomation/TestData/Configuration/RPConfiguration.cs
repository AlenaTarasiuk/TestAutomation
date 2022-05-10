using System.Configuration;

namespace TestAutomation.TestData.Configuration
{
    public class RPConfiguration : ConfigurationSection
    {
        private const string Section = "tests";
        private const string RPAuthenticationPropertyAppConfig = "RPAthentication";

        [ConfigurationProperty(RPAuthenticationPropertyAppConfig)]
        public NameValueConfigurationCollection AuthSettings => this[RPAuthenticationPropertyAppConfig] as NameValueConfigurationCollection;
        public static RPConfiguration GetSection() => ConfigurationManager.GetSection(Section) as RPConfiguration ?? new RPConfiguration();
    }
}