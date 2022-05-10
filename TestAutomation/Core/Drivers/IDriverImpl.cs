using OpenQA.Selenium;

namespace TestAutomation.Core.Drivers
{
    public interface IDriverImpl
    {
        IWebDriver InitDriver();
        IWebDriver InitDriver(string[] driverOptions);
    }
}