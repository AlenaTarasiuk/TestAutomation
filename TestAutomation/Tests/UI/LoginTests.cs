using NUnit.Framework;
using TestAutomation.Core.CustomAttributes;
using TestAutomation.Core.UIElements;
using TestAutomation.Core.Utilities.Helpers;
using TestAutomation.Repos.UIRepository;
using TestAutomation.TestData.Configuration;

namespace TestAutomation.Tests.UI
{

    public class LoginTests : BaseTest
    {
        private const string ExpectInvationInfo = "An error occurred while connecting to server: You do not have enough permissions. Bad credentials";
        private const string ExpectDemoTitle = "Your are on the public Demo Account. For loading your sensitive data, please use GitHub authorization";

        [Test]
        [WebUI]
        public void BadCredentials()
        {
            RPLoginPage.Instance.NavigateByURL();
            RPLoginPage.Instance.PageElements.LoginInput.FillWith(UserData.InvalidUser.Login);
            RPLoginPage.Instance.PageElements.PasswordInput.FillWith(UserData.InvalidUser.Password);
            RPLoginPage.Instance.PageElements.LoginBtn.Click();
            Assert.IsTrue(RPLoginPage.Instance.PageElements.ErrorMessage.Text().Contains(ExpectInvationInfo), 
                $"We expect '{ExpectInvationInfo}', but get this is '{RPLoginPage.Instance.PageElements.ErrorMessage.Text()}'");
        }

        [Test]
        [WebUI]
        public void SuccessfulDemo()
        {
            Core.Core.Driver.Navigate().GoToUrl($"{ConfigurationHelper.Configuration.AppSettings.DemoUrl}");
            RPDemoPage.Instance.PageElements.LoginInput.FillWith(UserData.DemoUser.Login);
            RPDemoPage.Instance.PageElements.PasswordInput.FillWith(UserData.DemoUser.Password);
            RPDemoPage.Instance.PageElements.LoginBtn.Click();
            Assert.IsTrue(RPDemoPage.Instance.PageElements.DemoTitle.Text().Contains(ExpectDemoTitle),
                $"We expect '{ExpectDemoTitle}', but get this is '{RPDemoPage.Instance.PageElements.DemoTitle.Text()}'");

        }
    }
}