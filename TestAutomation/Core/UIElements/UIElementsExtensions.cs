using OpenQA.Selenium;
using TestAutomation.Core.UIElements.Behaviors;
using TestAutomation.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using TestAutomation.Core.Utilities.Helpers;
using TestAutomation.Core.Waiters;
using TestAutomation.Core.Managers;

namespace TestAutomation.Core.UIElements
{
    public static class UIElementsExtensions
    {
        public static IWebElement ToSeleniumElement(this IUIElement element)
        {
            return Core.Driver.FindWithSmartWait(element.GetBy(), element.SecondsToWait, element.ExtraSeconds);
        }

        public static string Text(this IHasText element)
        {
            var text = element.ToSeleniumElement().Text;
            if (text == string.Empty)
            {
                text = element.ToSeleniumElement().GetAttribute("value");
            }
            return text;
        }

        public static void FillWith(this ICanInput element, string text)
        {
            element.ToSeleniumElement().Clear();
            element.ToSeleniumElement().SendKeys(text);
        }

        public static void Click(this ICanClick element, bool scrollToView = true)
        {
            var exceptions = new List<Exception>
            {
                new ElementNotInteractableException(),
                new TargetInvocationException(new ElementNotInteractableException()),
                new ElementClickInterceptedException(),
                new TargetInvocationException(new ElementClickInterceptedException())
            };

            if (scrollToView) element.ScrollToView();
            try
            {
                element.ToSeleniumElement().Click();
            }
            catch (Exception e)
            {
                // In IE due to https://github.com/SeleniumHQ/selenium/issues/5668 *sometimes* browser can't calculate proper coordinates
                // This can lead to ElementNotInteractableException with description that other element will receive the click.
                // To mitigate that, we can click by JS executor.
                if (exceptions.Contains(e) && ConfigManager.DriverType.Equals("IE"))
                {
                    JavaScriptExecutorHelper.Click(element as UIElement);
                }
                else throw;
            }
        }

        public static void ClickUntilClicks(this ICanClick element)
        {
            Retry.IfAnyError(element.SecondsToWait, () => element.Click());
        }

    }
}
