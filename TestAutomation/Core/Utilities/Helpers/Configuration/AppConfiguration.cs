using Newtonsoft.Json;

namespace TestAutomation.Core.Utilities.Helpers.Configuration
{
    public class AppConfiguration : IAppConfiguration
    {
        public AppSettings AppSettings { get; set; }
        public RPAuthentication RPAuthentication { get; set; }
    }

    public class AppSettings
    {
        private string _driverType;

        [JsonProperty("baseEndpoint")]
        public string BaseEndpoint { get; set; }

        [JsonProperty("loginUrl")]
        public string LoginUrl { get; set; }

        [JsonProperty("demoUrl")]
        public string DemoUrl { get; set; }

        [JsonProperty("environment")]
        public string Environment { get; set; }

        [JsonProperty("maxWaitTime")]
        public int DefaultMaxWaitTime { get; set; }

        [JsonProperty("DriverType")]
        public string DriverType
        {
            get => _driverType.ToUpper();
            set => _driverType = value;
        }
    }

    public class RPAuthentication
    {
        [JsonProperty("Login")]
        public string Login { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }
    } 
}
