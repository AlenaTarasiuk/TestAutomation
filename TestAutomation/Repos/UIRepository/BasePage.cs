using System;
using OpenQA.Selenium;
using TestAutomation.Core.Sessions;
using TestAutomation.Core.Utilities.Helpers;

namespace TestAutomation.Repos.UIRepository
{
    public class BasePage
    { 
        protected string _url = string.Empty;
        public Header Header => new Header();

        public BaseElements BasePageElements => new BaseElements();
        public sealed class BaseElements
        {
        }

        public string URL => string.Format(_url, ConfigurationHelper.Configuration.AppSettings.LoginUrl.ToLower());

        public virtual void NavigateByURL()
        {
            Core.Core.Driver.Navigate().GoToUrl(URL);
        }

        protected static T GetPageFromSession<T>()
        {
            var pageFromSession = TestSession.GetValue(typeof(T).Name);
            if (pageFromSession == null)
            {
                pageFromSession = (T)Activator.CreateInstance(typeof(T));
                TestSession.AddOrUpdate(typeof(T).Name, pageFromSession);
            }

            return (T)pageFromSession;
        }

        public static void OperURLInNewTab(string url)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Core.Core.Driver;
            executor.ExecuteScript(string.Format("window.open('{0}', '_blank');", url));
        }

        public void RefreshPage()
        {
            Core.Core.Driver.Navigate().Refresh();
        }

        public bool IsPageOpened => Core.Core.Driver.Url.Contains(_url);
    }
}

