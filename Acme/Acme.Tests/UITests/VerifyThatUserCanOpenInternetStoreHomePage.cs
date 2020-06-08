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
    public class VerifyThatUserCanOpenInternetStoreHomePage : BaseFixture<RegisterAndLoginFixtureRepository>
    {
        protected override string FixtureTestDataPath => "Register\\RegisterAndLoginFixtureTestData.json";
        private const string EXPECTED_TITLE = "Home";

        [Test]
        [AllureTag("Verify that user can open internet store home page")]
        public void VerifyThatUserCanOpenInternetStoreHomePageTest()
        {
            WordPressUA.LoginPage.Login(UrlManager.LoginPage(BaseUrl));

            WordPressUA.HomePage.Open();

            var actualTitle = WordPressUA.HomePage.GetTitle();

            Assert.AreEqual(EXPECTED_TITLE, actualTitle, $"Incorrect title, should be {0}, but was {1}",
                EXPECTED_TITLE, actualTitle);
        }
    }
}
