using Acme.Test;
using System.Configuration;

namespace Acme.UI
{
    public class LoginPage
    {
        private InputElement EmailField => ElementFactory.Create<InputElement>(Locator.Id("user_login"));
        private InputElement PasswordField => ElementFactory.Create<InputElement>(Locator.Id("user_pass"));
        private InputElement RememberMeCheckbox => ElementFactory.Create<InputElement>(Locator.Id("rememberme"));
        private InputElement LoginButton => ElementFactory.Create<InputElement>(Locator.Id("wp-submit"));

        public LoginPage Login(string url, bool staySignedIn = false)
        {
            RunConfig.BrowserStart();

            DriverManager.Current.OpenUrl(url);

            EnterLogin(ConfigurationManager.AppSettings["BaseLogin"])
                .EnterPassword(ConfigurationManager.AppSettings["BasePassword"])
                .StaySigned(staySignedIn)
                .ClickLoginButton();

            return this;
        }

        public LoginPage LoginAs(string url, string username, string password, bool staySignedIn = false)
        {
            RunConfig.BrowserStart();

            DriverManager.Current.OpenUrl(url);

            EnterLogin(username)
                .EnterPassword(password)
                .StaySigned(staySignedIn)
                .ClickLoginButton();

            return this;
        }

        private LoginPage EnterLogin(string username)
        {
            EmailField.EnterText(username);
            return this;
        }

        private LoginPage EnterPassword(string password)
        {
            PasswordField.EnterText(password);
            return this;
        }

        private LoginPage StaySigned(bool staySignedIn = false)
        {
            if (staySignedIn)
                RememberMeCheckbox.WaitAndClick();
            return this;
        }

        private LoginPage ClickLoginButton()
        {
            LoginButton.WaitAndClick();
            return this;
        }
    }
}
