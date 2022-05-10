namespace TestAutomation.Core.RestCore
{
    public class CoreClientFactory
    {
        public static CoreClient Create(string baseUrl)
        {
            return new CoreClient(baseUrl);
        }
    }
}
