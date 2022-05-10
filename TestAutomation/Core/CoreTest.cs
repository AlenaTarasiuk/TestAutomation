using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using TestAutomation.Core.CustomAttributes;
using TestAutomation.Core.Managers;
using TestAutomation.Core.Sessions;
using TestAutomation.Core.Utilities.Helpers;

namespace TestAutomation.Core
{
    public class CoreTest
    {
        public void StartDriver(bool headless = false)
        {

            if (ConfigManager.CurrentDriverType == Drivers.DriverType.IE) WinAPIHelper.MinimizeAllWindows();

            if (headless)
                Core.LaunchDriver(ConfigManager.CurrentDriverType, new[] { "--headless", "--start-maximized", "--disable-infobars" });
            else
                Core.LaunchDriver(ConfigManager.CurrentDriverType);
        }

        
        public void StartDriverForPlainTest()
        {
            if (AttributeHelper.AttributeExistInCurrentTest(typeof(WebUI)))
            {
                if (AttributeHelper.AttributeExistInCurrentTest(typeof(HeadlessMode)))
                    StartDriver(true);
                else
                    StartDriver();
            }
        }

        public void TakeScreenShotOnFail()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Error || TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                Screenshot ss = ((ITakesScreenshot)Core.Driver).GetScreenshot();
                var fileName = TestContext.CurrentContext.Test.MethodName + "-ss.png";
                var fullPathForFile = TestContext.CurrentContext.TestDirectory + "\\" + fileName;
                ss.SaveAsFile(fullPathForFile, ScreenshotImageFormat.Png);
                try
                {
                    //Bridge.LogMessage(ReportPortal.Client.Models.LogLevel.Warning, "Failed with this screenshot: {rp#file#" + fullPathForFile + "}");
                }
                catch (Exception ex)
                {
                    TestContext.Progress.WriteLine(ex.Message);
                }
            }
        }

        public string TakeScreenshot(string screenshotContextName = "")
        {
            var contextMessage = screenshotContextName.Equals("")
                ? "Screenshot added while the execution"
                : screenshotContextName;

            var ss = ((ITakesScreenshot)Core.Driver).GetScreenshot();
            screenshotContextName = screenshotContextName.Equals("")
                ? $"{TestContext.CurrentContext.Test.MethodName}_{DateTime.Now.ToLongTimeString().Replace(':', '_')}-ss.png"
                : $"{screenshotContextName}-ss.png";

            var fullPathForFile = $"{TestContext.CurrentContext.TestDirectory}\\{screenshotContextName}";
            ss.SaveAsFile(fullPathForFile, ScreenshotImageFormat.Png);

            try
            {
                //Bridge.LogMessage(ReportPortal.Client.Models.LogLevel.Info, contextMessage + ": {rp#file#" + fullPathForFile + "}");
                return fullPathForFile;
            }
            catch (Exception ex)
            {
                TestContext.Progress.WriteLine(ex.Message);
                return string.Empty;
            }
        }

        public void KillDriver()
        {
            TakeScreenShotOnFail();
            if (TestSession.GetValue(TestSessionKey.Driver) != null)
            {
                Core.Driver.Quit();
                TestSession.Remove();
            }
        }

        [TearDown]
        public void KillDriverForPlainTest()
        {
            if (AttributeHelper.AttributeExistInCurrentTest(typeof(WebUI)))
            {
                KillDriver();
            }
        }
    }
}
