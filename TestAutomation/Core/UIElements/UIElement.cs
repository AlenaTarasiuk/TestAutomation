using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestAutomation.Core.Enums;
using TestAutomation.Core.Managers;
using TestAutomation.Core.Objects;
using TestAutomation.Core.Utilities;

namespace TestAutomation.Core.UIElements
{
    public class UIElement : IUIElement
    {
        private string _locator;
        private int _secondsToWait;
        private int _extraSeconds;
        private LocatorType _locatorType;

        public void ScrollToView()
        {
            string scrollElementIntoMiddle = "var viewPortHeight = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);"
                                       + "var elementTop = arguments[0].getBoundingClientRect().top;"
                                       + "window.scrollBy(0, elementTop-(viewPortHeight/2));";

            (Core.Driver as IJavaScriptExecutor).ExecuteScript(scrollElementIntoMiddle, this.ToSeleniumElement());

            Thread.Sleep(750);
        }

        public UIElement(string locator, int secondsToWait = 1, int extraSeconds = 0, LocatorType locatorType = LocatorType.XPath)
        {
            _locator = locator;
            _secondsToWait = secondsToWait;
            _extraSeconds = extraSeconds;
            _locatorType = locatorType;
        }

        public UIElement(List<Locator> locators)
        {
            Locator targetLocator;
            switch (ConfigManager.CurrentDriverType)
            {
                case Drivers.DriverType.Chrome:
                    targetLocator = locators.FirstOrDefault(l => l.InstanceType == InstanceType.API);
                    break;
                default:
                    targetLocator = locators.FirstOrDefault(l => l.InstanceType == InstanceType.WebUI);
                    break;
            }

            _locator = targetLocator.Value;
            _secondsToWait = targetLocator.SecondsToWait;
            _extraSeconds = targetLocator.ExtraSeconds;
            _locatorType = targetLocator.LocatorType;
        }

        public string Locator => _locator;

        public int SecondsToWait => _secondsToWait;

        public int ExtraSeconds => _extraSeconds;

        public LocatorType LocatorType => _locatorType;


        public void Hover()
        {
            Actions action = new Actions(Core.Driver);
            action.MoveToElement(this.ToSeleniumElement()).Perform();
        }

        public bool IsDisplayed()
        {
            return Core.Driver.Wait(_secondsToWait).UntilUIElement(this).WillBeDisplayed();
        }

        public bool IsHidden()
        {
            return Core.Driver.Wait(_secondsToWait).UntilUIElement(this).WillBeHidden();
        }

        public bool IsEnabled()
        {
            return Core.Driver.Wait(_secondsToWait).UntilUIElement(this).WillBeEnabled();
        }
        public bool IsDisabled()
        {
            return Core.Driver.Wait(_secondsToWait).UntilUIElement(this).WillEBeDisabled();
        }

        public string GetAttribute(string attributeName)
        {
            return this.ToSeleniumElement().GetAttribute(attributeName);
        }

        public string GetCssValue(string cssPropertyName)
        {
            return this.ToSeleniumElement().GetCssValue(cssPropertyName);
        }

        public T FindElement<T>(string xpathLocator, int secondsToWait = 10, int extraSecondsToWait = 10, LocatorType locatorType = LocatorType.XPath) where T : UIElement
        {
            return Activator.CreateInstance(typeof(T), new object[] { String.Concat(Locator, xpathLocator), secondsToWait, extraSecondsToWait, locatorType }) as T;
        }

        public UIElement FindElement(string xpathLocator, int secondsToWait = 10, int extraSecondsToWait = 10, LocatorType locatorType = LocatorType.XPath)
        {
            return new UIElement(String.Concat(Locator, xpathLocator), secondsToWait, extraSecondsToWait, LocatorType);
        }

        public UIList<UIElement> FindElements(string xpathLocator, int secondsToWait = 10, int extraSecondsToWait = 10, LocatorType locatorType = LocatorType.XPath)
        {
            return new UIList<UIElement>(String.Concat(Locator, xpathLocator), secondsToWait, extraSecondsToWait, LocatorType);
        }

        public By GetBy()
        {
            switch (LocatorType)
            {
                case LocatorType.ID:
                    return By.Id(Locator);
                case LocatorType.ClassName:
                    return By.ClassName(Locator);
                case LocatorType.Name:
                    return By.Name(Locator);
                case LocatorType.TagName:
                    return By.TagName(Locator);
                case LocatorType.CssSelector:
                    return By.CssSelector(Locator);
                case LocatorType.XPath:
                default:
                    return By.XPath(Locator);
            }
        }
    }
}
