using TestAutomation.Core.Drivers.Implementations;
using System;

namespace TestAutomation.Core.Drivers
{
    public enum DriverType
    {
        [Default]
        [Implementation(typeof(ChromeDriverImpl))]
        Chrome,
        [Implementation(typeof(FirefoxDriverImpl))]
        Firefox,
        [Implementation(typeof(IEDriverImpl))]
        IE,
        [Implementation(typeof(EdgeDriverImpl))]
        Edge
    }

    public static class DriverTypeHelper
    {
        public static DriverType GetDriverTypeByString(string browser)
        {
            foreach (DriverType driverType in Enum.GetValues(typeof(DriverType)))
            {
                if (driverType.ToString().ToLower().Trim() == browser.ToLower().Trim())
                {
                    return driverType;
                }
            }
            throw new Exception("Can't parse browser name to DriverType enum");
        }

        public static DriverType DefaultDriverType
        {
            get
            {
                var type = typeof(DriverType);
                if (!type.IsEnum) throw new InvalidOperationException();
                foreach (var field in type.GetFields())
                {
                    var attribute = Attribute.GetCustomAttribute(field,
                        typeof(DefaultAttribute)) as DefaultAttribute;
                    if (attribute != null)
                    {
                        return (DriverType)field.GetValue(null);
                    }
                }
                throw new ArgumentException("No default DriverType available");
            }
        }
    }

    sealed class ImplementationAttribute : Attribute
    {
        public Type ImplementationType { get; set; }

        public ImplementationAttribute(Type type)
        {
            ImplementationType = type;
        }
    }

    public class DefaultAttribute : Attribute { }
}

