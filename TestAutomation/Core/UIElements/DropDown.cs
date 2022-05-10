using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using TestAutomation.Core.Enums;
using TestAutomation.Core.Objects;
using TestAutomation.Core.UIElements.Behaviors;

namespace TestAutomation.Core.UIElements
{
    public class DropDown : UIElement, ICanDropdown, IHasText, ICanFocus
    {
        public DropDown(string locator, int secondsToWait = 1, int extraSeconds = 0, LocatorType locatorType = LocatorType.XPath) : base(locator, secondsToWait, extraSeconds, locatorType) { }

        public DropDown(List<Locator> locators) : base(locators) { }

        public string Text()
        {
            var dropdown = new SelectElement(this.ToSeleniumElement());
            return dropdown.SelectedOption.Text;
        }
    }
}