using NUnit.Framework;

namespace TestAutomation.Tests.UI
{
    [TestFixture]
    public class BaseTest : Core.CoreTest
    {
        [SetUp]
        public void InitiateWebDriver()
        {
            new Core.CoreTest().StartDriver();
        }

        [TearDown]
        public void QuitWebDriver()
        {
            new Core.CoreTest().KillDriver();
        }
    }
}
