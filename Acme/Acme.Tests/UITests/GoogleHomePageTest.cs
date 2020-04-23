using Acme.UI;
using NUnit.Framework;
using System.Threading;

namespace Acme.Test.UITests
{
   // [TestFixture]
    public class GoogleHomePageTest
    {
        //[SetUp]
        public void SetUpTest()
        {
            DriverManager.Current = Driver.GetForRemout();
            DriverManager.Current.Url = "https://www.google.com.ua/";
            DriverManager.Current.MaximizeWindow();
        }

        //[Test]
        public void GoogleHomeTest()
        {
            GooglePages.HomePage.EnterSearchText("softserve");
            Thread.Sleep(1000);
            GooglePages.HomePage.ClickSearchInGoogleInput();
        }

        //[TearDown]
        public void TearDownTest()
        {
            DriverManager.Current.Quit();
        }
    }
}
