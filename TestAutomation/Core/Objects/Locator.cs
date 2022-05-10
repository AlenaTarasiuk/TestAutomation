using TestAutomation.Core.Enums;

namespace TestAutomation.Core.Objects
{
    public class Locator
    {
        public InstanceType InstanceType { get; private set; }
        public LocatorType LocatorType { get; private set; }
        public string Value { get; private set; }
        public int SecondsToWait { get; private set; }
        public int ExtraSeconds { get; private set; }

        public Locator(string value, LocatorType locatorType = LocatorType.XPath, InstanceType instanceType = InstanceType.WebUI, int secondsToWait = 1, int extraSeconds = 0)
        {
            Value = value;
            InstanceType = instanceType;
            LocatorType = locatorType;
            SecondsToWait = secondsToWait;
            ExtraSeconds = extraSeconds;
        }
    }
}