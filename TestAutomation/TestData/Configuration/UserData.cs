using TestAutomation.Core.RestCore;

namespace TestAutomation.TestData.Configuration
{
    public static class UserData
    {
        public static IRPUser DemoUser => new RPUser()
        {
            Login = "default",
            Password = "1q2w3e",
        };

        public static IRPUser InvalidUser => new RPUser()
        {
            Login = "12345",
            Password = "54321",
        };
    }
}
