namespace TestAutomation.Core.RestCore
{
    public class RequestFactory
    {
        public static T Create<T>() where T : new()
        {
            return new T();
        }
    }
}
