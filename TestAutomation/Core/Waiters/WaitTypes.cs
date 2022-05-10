using OpenQA.Selenium;
using TestAutomation.Core.UIElements;

namespace TestAutomation.Core.Waiters
{
    public class WaitTypes
    {
        private readonly IWebDriver _driver;
        private readonly int _waitTime;

        public WaitTypes(IWebDriver driver, int waitTime)
        {
            _driver = driver;
            _waitTime = waitTime;
        }

        public PageWaiters UntilPage => new PageWaiters(_driver, _waitTime);
        public ElementWaiters UntilSeleniumElement(By locator)
        {
            return new ElementWaiters(_driver, _waitTime, locator);
        }

        public ElementWaiters UntilUIElement(IUIElement element)
        {
            return new ElementWaiters(_driver, _waitTime, element.GetBy());
        }
    }
}