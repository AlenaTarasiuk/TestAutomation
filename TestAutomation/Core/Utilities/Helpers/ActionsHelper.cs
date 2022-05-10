using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using TestAutomation.Core.UIElements;

namespace TestAutomation.Core.Utilities.Helpers
{
    public static class ActionsHelper
    {
        public static void Click(UIElement element)
        {
            new Actions(Core.Driver).Click(element.ToSeleniumElement()).Perform();
        }

        public static void ClickAndHold(UIElement element)
        {
            new Actions(Core.Driver).ClickAndHold(element.ToSeleniumElement()).Perform();
        }

        public static void ClearAndSendText(UIElement element, string text)
        {
            DoubleClick(element);
            SendKeys(Keys.Backspace);
            SendKeys(text);
        }

        public static void DoubleClick(UIElement element)
        {
            new Actions(Core.Driver).DoubleClick(element.ToSeleniumElement()).Perform();
        }

        public static void MoveToElement(UIElement element)
        {
            new Actions(Core.Driver).MoveToElement(element.ToSeleniumElement()).Perform();
        }

        public static void SendKeys(UIElement element, String keysToSend)
        {
            new Actions(Core.Driver).SendKeys(element.ToSeleniumElement(), keysToSend).Perform();
        }

        public static void SendKeys(String keysToSend)
        {
            new Actions(Core.Driver).SendKeys(keysToSend).Perform();
        }

        public static void DragAndDrop(UIElement initialElement, UIElement targetElement)
        {
            new Actions(Core.Driver).DragAndDrop(initialElement.ToSeleniumElement(), targetElement.ToSeleniumElement()).Perform();
        }

        public static void DragAndDropToOffset(UIElement initialElement, int offsetX, int offsetY)
        {
            new Actions(Core.Driver).DragAndDropToOffset(initialElement.ToSeleniumElement(), offsetX, offsetY).Perform();
            Thread.Sleep(1000);
        }

        public static void ClickByOffset(int offsetX, int offsetY)
        {
            new Actions(Core.Driver).MoveByOffset(offsetX, offsetY).Click().Build().Perform();
        }
    }
}
