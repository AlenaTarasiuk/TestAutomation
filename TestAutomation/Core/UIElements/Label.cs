using System.Collections.Generic;
using TestAutomation.Core.Enums;
using TestAutomation.Core.Objects;
using TestAutomation.Core.UIElements.Behaviors;

namespace TestAutomation.Core.UIElements
{
    public class Label : UIElement, IHasText, ICanClick
    {
        public Label(string locator, int secondsToWait = 2, int extraSeconds = 0, LocatorType locatorType = LocatorType.XPath) : base(locator, secondsToWait, extraSeconds, locatorType) { }
        public Label(List<Locator> locators) : base(locators) { }
    }
}