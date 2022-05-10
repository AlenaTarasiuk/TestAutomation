using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestAutomation.Core.Drivers.Implementations
{
    class FirefoxDriverImpl : IDriverImpl
    {
        public IWebDriver InitDriver()
        {
            var service = FirefoxDriverService.CreateDefaultService();
            var options = new FirefoxOptions();
            options.SetPreference("security.sandbox.content.level", 5);
            options.AcceptInsecureCertificates = true;
            var driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(180));
            driver.Manage().Window.Maximize();
            return driver;
        }

        public IWebDriver InitDriver(string[] driverOptions)
        {
            var service = FirefoxDriverService.CreateDefaultService();
            var options = new FirefoxOptions();
            options.AddArguments(driverOptions);
            var driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(180));
            return driver;
        }
    }
}