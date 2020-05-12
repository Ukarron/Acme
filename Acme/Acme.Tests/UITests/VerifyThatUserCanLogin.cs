using Acme.Test.Register;
using Acme.UI;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using System.Configuration;

namespace Acme.Test.UITests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("UI")]
    public class VerifyThatUserCanLogin : BaseFixture<RegisterAndLoginFixtureRepository>
    {
        protected override string FixtureTestDataPath => "Register\\RegisterAndLoginFixtureTestData.json";
        private const string EXPECTED_TEXT = "My Account";

        [SetUp]
        public void SetUpTest()
        {
            DriverManager.Current = Driver.GetForRemout();
            DriverManager.Current.MaximizeWindow();
        }

        [Test]
        [AllureTag("Verify if user can login into the application")]
        public void VerifyThatUserCanLoginTest()
        {
            OpenCart.LoginPage.Open();
            OpenCart.LoginPage.EnterEmail(ConfigurationManager.AppSettings["BaseEmail"]);
            OpenCart.LoginPage.EnterPassword(ConfigurationManager.AppSettings["BasePassword"]);
            var source = DriverManager.Current.GetPageSource();
            OpenCart.LoginPage.ClickLoginButton();
        }
    }
}
