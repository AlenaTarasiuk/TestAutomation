using OpenQA.Selenium;
using System;
using TestAutomation.Core.Drivers;
using TestAutomation.Core.Sessions;

namespace TestAutomation.Core
{
    public class Core
    {
        public static void LaunchDriver(DriverType type)
        {
            if (TestSession.GetValue(TestSessionKey.Driver) != null)
            {
                return;
            }
            var driver = Drivers.Driver.GetWebDriver(type);
            TestSession.AddOrUpdate(TestSessionKey.Driver, driver);
        }

        public static void LaunchDriver(DriverType type, string[] driverOptions)
        {
            if (TestSession.GetValue(TestSessionKey.Driver) != null)
            {
                return;
            }
            var driver = Drivers.Driver.GetWebDriver(type, driverOptions);
            TestSession.AddOrUpdate(TestSessionKey.Driver, driver);
        }

        public static IWebDriver Driver
        {
            get
            {
                if (TestSession.GetValue(TestSessionKey.Driver) == null)
                {
                    //throw new Exception("No driver initialized");
                }
                return (IWebDriver)TestSession.GetValue(TestSessionKey.Driver);
            }
        }
    }
}
