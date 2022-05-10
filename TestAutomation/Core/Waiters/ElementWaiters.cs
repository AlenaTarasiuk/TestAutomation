using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace TestAutomation.Core.Waiters
{
    public class ElementWaiters
    {
        private readonly IWebDriver _driver;
        private readonly int _waitTime;
        private readonly By _locator;
        private Exception[] ElementNotPresentExceptions => GetElementNotPresentExceptions().ToArray();
        private Exception[] ElementCommonExceptions
        {
            get
            {
                var exceptions = GetElementNotPresentExceptions();
                exceptions.Add(new ElementNotInteractableException());
                exceptions.Add(new TargetInvocationException(new ElementNotInteractableException()));
                exceptions.Add(new InvalidElementStateException());
                exceptions.Add(new TargetInvocationException(new InvalidElementStateException()));
                return exceptions.ToArray();
            }
        }

        public ElementWaiters(IWebDriver driver, int waitTime, By locator)
        {
            _driver = driver;
            _waitTime = waitTime;
            _locator = locator;
        }

        public bool WillBeDisplayed(params Exception[] exceptions)
        {
            return Retry.IfFalseOrError(_waitTime, () => _driver.FindElement(_locator).Displayed, exceptions.Length != 0 ? exceptions : ElementCommonExceptions);
        }

        public bool WillBeEnabled(params Exception[] exceptions)
        {
            return Retry.IfFalseOrError(_waitTime, () => _driver.FindElement(_locator).Enabled, exceptions.Length != 0 ? exceptions : ElementCommonExceptions);
        }

        public bool WillBeHidden(params Exception[] exceptions)
        {
            return Retry.IfTrueOrError(_waitTime, () => _driver.FindElement(_locator).Displayed, exceptions.Length != 0 ? exceptions : ElementNotPresentExceptions);
        }

        public bool WillEBeDisabled(params Exception[] exceptions)
        {
            return Retry.IfTrueOrError(_waitTime, () => _driver.FindElement(_locator).Enabled, exceptions.Length != 0 ? exceptions : ElementNotPresentExceptions);
        }

        public bool WillHaveText(string text, bool useStrictCriteria = false, params Exception[] exceptions)
        {
            if (useStrictCriteria)
            {
                return Retry.IfFalseOrError(_waitTime, () => _driver.FindElement(_locator).Text.Equals(text), exceptions.Length != 0 ? exceptions : ElementCommonExceptions);
            }
            else
            {
                return Retry.IfFalseOrError(_waitTime, () => _driver.FindElement(_locator).Text.Contains(text), exceptions.Length != 0 ? exceptions : ElementCommonExceptions);
            }
        }

        public bool WillNotHaveText(string text, bool useStrictCriteria = false, params Exception[] exceptions)
        {
            if (useStrictCriteria)
            {
                return Retry.IfTrueOrError(_waitTime, () => _driver.FindElement(_locator).Text.Equals(text), exceptions.Length != 0 ? exceptions : ElementCommonExceptions);
            }
            else
            {
                return Retry.IfTrueOrError(_waitTime, () => _driver.FindElement(_locator).Text.Contains(text), exceptions.Length != 0 ? exceptions : ElementCommonExceptions);
            }
        }

        private List<Exception> GetElementNotPresentExceptions()
        {
            List<Exception> exceptions = new List<Exception>();
            exceptions.Add(new WebDriverException());
            exceptions.Add(new TargetInvocationException(new WebDriverException()));
            exceptions.Add(new NoSuchElementException());
            exceptions.Add(new TargetInvocationException(new NoSuchElementException()));
            exceptions.Add(new ElementNotVisibleException());
            exceptions.Add(new TargetInvocationException(new ElementNotVisibleException()));
            exceptions.Add(new StaleElementReferenceException());
            exceptions.Add(new TargetInvocationException(new StaleElementReferenceException()));
            return exceptions;
        }
    }
}
