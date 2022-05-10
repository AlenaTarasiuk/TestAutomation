using NUnit.Framework;
using System;
using System.Reflection;

namespace TestAutomation.Core.Utilities.Helpers
{
    public class AttributeHelper
    {
        public static bool AttributeExistInCurrentTest(Type attribute)
        {
            var vClass = GetType(TestContext.CurrentContext.Test.ClassName);
            foreach (MethodInfo method in vClass.GetMethods())
            {
                foreach (Attribute attr in method.GetCustomAttributes(true))
                {
                    if (method.Name == TestContext.CurrentContext.Test.MethodName)
                    {
                        if (attribute.UnderlyingSystemType == attr.GetType())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static Type GetType(string typeName)
        {
            var type = Type.GetType(typeName);
            if (type != null) return type;
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(typeName);
                if (type != null)
                    return type;
            }
            return null;
        }
    }
}