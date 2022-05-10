using OpenQA.Selenium;
using System;
using System.Linq;
namespace TestAutomation.Core.Drivers
{
    sealed class Driver
    {
        public static IWebDriver GetWebDriver(DriverType driverType)
        {
            var implType = GetImplementationType(driverType);
            return ((IDriverImpl)Activator.CreateInstance(implType)).InitDriver();
        }

        public static IWebDriver GetWebDriver(DriverType driverType, string[] driverOptions)
        {
            var implType = GetImplementationType(driverType);
            return ((IDriverImpl)Activator.CreateInstance(implType)).InitDriver(driverOptions);
        }
       
        private static Type GetImplementationType(DriverType driverType)
        {
            var type = typeof(DriverType);
            var memInfo = type.GetMember(driverType.ToString());
            var attributes = memInfo.Single().GetCustomAttributes(typeof(ImplementationAttribute), false);
            return ((ImplementationAttribute)attributes.Single()).ImplementationType;
        }
    }
}