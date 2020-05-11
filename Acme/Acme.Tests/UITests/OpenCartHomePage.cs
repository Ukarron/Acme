using Acme.Test.Register;
using Acme.UI;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Acme.Test.UITests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("UI")]
    public class OpenCartHomePage : BaseFixture<RegisterAndLoginFixtureRepository>
    {
        private const string EXPECTED_TITLE = "Your Store";
        protected override string FixtureTestDataPath => "Register\\RegisterAndLoginFixtureTestData.json";

        [SetUp]
        public void SetUpTest()
        {
            DriverManager.Current = Driver.GetForRemout();
            DriverManager.Current.MaximizeWindow();
        }

        [Test]
        [AllureTag("User able to open Home page")]
        public void OpenCartHomePageTest()
        {
            OpenCart.HomePage.Open();
            OpenCart.TopBar.ClickMyAccountIcon();
            OpenCart.MyAccountDropDown.ClickLogin();
            Assert.AreEqual(EXPECTED_TITLE, OpenCart.HomePage.GetTitle());
        }
    }
}
