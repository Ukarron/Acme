using Acme.UI;
using NUnit.Framework;

namespace Acme.Test.UITests
{
    [TestFixture]
    public class GoogleHomePageTest
    {
        [SetUp]
        public void SetUpTest()
        {
            DriverManager.Current = Driver.GetFor(BrowserType.Chrome);
            DriverManager.Current.Url = "https://www.google.com.ua/";
            DriverManager.Current.MaximizeWindow();
        }

        [Test]
        public void GoogleHomeTest()
        {
            GooglePages.HomePage.EnterSearchText("SoftServe");
            GooglePages.HomePage.ClickSearchInGoogleInput();
        }

        [TearDown]
        public void TearDownTest()
        {
            DriverManager.Current.Quit();
        }
    }
}
