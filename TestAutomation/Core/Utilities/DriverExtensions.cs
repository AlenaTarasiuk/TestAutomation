using OpenQA.Selenium;
using TestAutomation.Core.Waiters;

namespace TestAutomation.Core.Utilities
{
    public static class DriverExtensions
    {
        public static WaitTypes Wait(this IWebDriver driver, int waitTime = 2)
        {
            return new WaitTypes(driver, waitTime);
        }

        public static IWebElement FindWithSmartWait(this IWebDriver driver, By locator, int secondsToWait, int extraTime)
        {
            try
            {
                Core.Driver.Wait(secondsToWait).UntilSeleniumElement(locator).WillBeDisplayed();
                return Core.Driver.FindElement(locator);
            }
            catch
            {
                Core.Driver.Wait(extraTime).UntilSeleniumElement(locator).WillBeDisplayed();
                return Core.Driver.FindElement(locator);
            }
        }

        public static void ExecJS(this IWebDriver driver, string script, params object[] args)
        {
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script, args);
        }
    }
}

