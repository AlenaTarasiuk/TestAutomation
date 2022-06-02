using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestAutomation.Core.Drivers.Implementations
{
    class ChromeDriverImpl : IDriverImpl
    {
        public IWebDriver InitDriver()
        {
            var service = ChromeDriverService.CreateDefaultService();
            var options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArgument("disable-infobars");
            options.AddArguments("--no-sandbox");
            return new ChromeDriver(service, options, TimeSpan.FromSeconds(180));
        }

        public IWebDriver InitDriver(string[] driverOptions)
        {
            var service = ChromeDriverService.CreateDefaultService();
            var options = new ChromeOptions();
            options.AddArguments(driverOptions);
            return new ChromeDriver(service, options, TimeSpan.FromSeconds(180));
        }
    }
}
