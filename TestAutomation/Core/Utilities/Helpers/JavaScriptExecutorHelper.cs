using OpenQA.Selenium;
using TestAutomation.Core.UIElements;

namespace TestAutomation.Core.Utilities.Helpers
{
    public static class JavaScriptExecutorHelper
    {
        public static void Click(UIElement element)
        {
            ((IJavaScriptExecutor)Core.Driver).ExecuteScript("arguments[0].click();", element.ToSeleniumElement());
        }

        /// <summary>
        /// This method uses straight JS code to scroll to view element.
        /// That may be useful for FF tests execution, where due to the driver specifics
        /// Sometimes we can't navigate to the element correctly by use of ScrollElementToView.
        /// </summary>
        public static void ScrollElementIntoView(UIElement element)
        {
            ((IJavaScriptExecutor)Core.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element.ToSeleniumElement());
        }

        /// <summary>
        /// This method uses straight JS code to scroll to view element.
        /// That may be useful for FF tests execution, where due to the driver specifics
        /// Sometimes we can't navigate to the element correctly by use of ScrollElementToView.
        /// </summary>
        public static void ScrollElementIntoView(IWebElement element)
        {
            ((IJavaScriptExecutor)Core.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
    }
}
