namespace TestAutomation.Core.Utilities.Helpers.Configuration
{
    public interface IAppConfiguration
    {
        public AppSettings AppSettings { get; set; }
        public RPAuthentication RPAuthentication { get; set; }
    }
}