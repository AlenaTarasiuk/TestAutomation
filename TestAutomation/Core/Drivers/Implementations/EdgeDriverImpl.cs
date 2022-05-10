using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;

namespace TestAutomation.Core.Drivers.Implementations
{
    class EdgeDriverImpl : IDriverImpl
    {
        public IWebDriver InitDriver()
        {
            var options = new EdgeOptions();
            options.UseChromium = true;
            options.AddArguments("--start-maximized");
            options.AddArgument("disable-infobars");

            return new EdgeDriver(options);
        }

        public IWebDriver InitDriver(string[] driverOptions)
        {
            var options = new EdgeOptions();
            options.UseChromium = true;
            options.AddArguments(driverOptions);
            return new EdgeDriver(options);
        }
    }
}