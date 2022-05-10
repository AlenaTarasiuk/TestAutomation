using NUnit.Framework;
using System;


namespace TestAutomation.Core.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method)] public class Smoke : CategoryAttribute { }
}