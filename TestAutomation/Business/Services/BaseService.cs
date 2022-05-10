using System.Configuration;
using TestAutomation.TestData.Configuration;

namespace TestAutomation.Business.Services
{
    public class BaseService
    {
        public NameValueConfigurationCollection AuthConfig => RPConfiguration.GetSection().AuthSettings;
    }
}
