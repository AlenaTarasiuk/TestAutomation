using OpenQA.Selenium;
using TestAutomation.Core.Enums;

namespace TestAutomation.Core.UIElements
{
    public interface IUIElement
    {
        string Locator { get; }
        int SecondsToWait { get; }
        int ExtraSeconds { get; }
        LocatorType LocatorType { get; }
        void ScrollToView();
        void Hover();
        By GetBy();
    }
}
