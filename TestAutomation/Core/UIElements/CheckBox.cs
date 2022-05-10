using System.Collections.Generic;
using TestAutomation.Core.Enums;
using TestAutomation.Core.Objects;
using TestAutomation.Core.UIElements.Behaviors;

namespace TestAutomation.Core.UIElements
{
    public class CheckBox : UIElement, ICanCheck
    {
        public CheckBox(string locator, int secondsToWait = 1, int extraSeconds = 0, LocatorType locatorType = LocatorType.XPath) : base(locator, secondsToWait, extraSeconds, locatorType) { }
        public CheckBox(List<Locator> locators) : base(locators) { }
    }
}