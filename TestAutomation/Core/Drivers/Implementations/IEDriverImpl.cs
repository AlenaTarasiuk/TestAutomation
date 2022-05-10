using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;

namespace TestAutomation.Core.Drivers.Implementations
{
    class IEDriverImpl : IDriverImpl
    {
        public IWebDriver InitDriver()
        {
            var service = InternetExplorerDriverService.CreateDefaultService();
            var options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.EnsureCleanSession = true;
            options.EnableNativeEvents = true;
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.AcceptAndNotify;
            options.IgnoreZoomLevel = true;
            options.RequireWindowFocus = true;
            options.PageLoadStrategy = PageLoadStrategy.Eager;
            var driver = new InternetExplorerDriver(service, options, TimeSpan.FromSeconds(180));
            driver.Manage().Window.Maximize();
            return driver;
        }

        public IWebDriver InitDriver(string[] driverOptions)
        {
            return InitDriver();
        }
    }
}