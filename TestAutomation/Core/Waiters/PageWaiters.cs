using OpenQA.Selenium;

namespace TestAutomation.Core.Waiters
{
    public class PageWaiters
    {
        private readonly IWebDriver _driver;
        private readonly int _waitTime;

        public PageWaiters(IWebDriver driver, int waitTime)
        {
            _driver = driver;
            _waitTime = waitTime;
        }

        public bool WillHaveTitle(string title)
        {
            return Retry.IfFalse(_waitTime, () => _driver.Title == title);
        }

        public bool WillContainTitle(string title)
        {
            return Retry.IfFalse(_waitTime, () => _driver.Title.Contains(title));
        }

        public bool WillHaveUrl(string url)
        {
            return Retry.IfFalse(_waitTime, () => _driver.Url == url);
        }

        public bool WillContainUrl(string url)
        {
            return Retry.IfFalse(_waitTime, () => _driver.Url.Contains(url));
        }
    }
}
