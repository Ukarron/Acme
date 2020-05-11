using Acme.UI;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Acme.Test.UITests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("UI")]
    public class OpenCartHomePage : BaseFixture<BaseFixtureRepository>
    {
        private const string EXPECTED_TITLE = "Your Store";

        protected override string FixtureTestDataPath => throw new System.NotImplementedException();

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
            Assert.AreEqual(EXPECTED_TITLE, OpenCart.HomePage.GetTitle());
        }

        [TearDown]
        public void TearDownTest()
        {
            DriverManager.Current.Quit();
        }
    }
}
