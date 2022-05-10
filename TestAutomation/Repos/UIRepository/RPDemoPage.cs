using TestAutomation.Core.UIElements;
using TestAutomation.Core.Utilities.Helpers;

namespace TestAutomation.Repos.UIRepository
{
    class RPDemoPage : BasePage
    {
        public static RPDemoPage Instance => GetPageFromSession<RPDemoPage>();

        public RPDemoPage()
        {
            _url = ConfigurationHelper.Configuration.AppSettings.DemoUrl;
        }

        public Elements PageElements => new Elements();

        public sealed class Elements
        {
            public Button LoginWithEpamBtn { get; set; } = new Button("//span[contains(text(), 'Login with EPAM')]", 1, 180);
            public Input LoginInput { get; set; } = new Input("//input[@type='text']", 5);
            public Input PasswordInput { get; set; } = new Input("//input[@type='password']");
            public Button LoginBtn { get; set; } = new Button("//button[contains(text(), 'Login')]", 1, 180);

            public Link ForgotPassword => new Link("//a[contains(text(), 'Forgot password?')]", 10);

            public Label WelcomeMesssage => new Label("//span[text()='login to your account']", 5);
            public Label Title => new Label("//title", 5);
            public Label ErrorMessage => new Label("//div[contains(@class, 'notificationItem__message')]/p", 15, 15);

            public Label DemoTitle => new Label("//span[contains(@class, 'demoBanner__description')]", 15, 15);
        }

        public bool IsWelcomeMessageDisplayed()
        {
            return PageElements.WelcomeMesssage.IsDisplayed();
        }
    }
}
