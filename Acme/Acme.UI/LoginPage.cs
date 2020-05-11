using System.Configuration;

namespace Acme.UI
{
    public class LoginPage
    {
        private InputElement EmailField => ElementFactory.Create<InputElement>(Locator.Id("input-email"));
        private InputElement PasswordField => ElementFactory.Create<InputElement>(Locator.Id("input-password"));
        private InputElement LoginButton => ElementFactory.Create<InputElement>(Locator.Css("input.btn.btn-primary"));

        public void Open()
        {
            DriverManager.Current.OpenUrl(ConfigurationManager.AppSettings["RemoteUrl"]);
        }

        public LoginPage EnterEmail(string email)
        {
            EmailField.EnterText(email);
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            PasswordField.EnterText(password);
            return this;
        }

        public LoginPage ClickLoginButton()
        {
            LoginButton.WaitAndClick();
            return this;
        }
    }
}
