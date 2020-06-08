using Acme.Framework.Core.Rest;
using Acme.UI;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.IO;

namespace Acme.Test
{
    [TestFixture]
    public abstract class BaseFixture<TBaseRepository> where TBaseRepository : BaseFixtureRepository
    {
        private const string BaseTestDataPath = "BaseFixtureData.json";

        protected abstract string FixtureTestDataPath { get; }
        protected TBaseRepository Repository { get; private set; }
        protected Client Client { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var baseJson = JObject.Parse(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, BaseTestDataPath)));
            var fixtureJson = JObject.Parse(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FixtureTestDataPath)));
            fixtureJson.Merge(baseJson);
            Repository = fixtureJson.ToObject<TBaseRepository>();
            Client = new Client(Repository.BaseUrl);

            if (ConfigurationManager.AppSettings["RunRemotely"].Equals("true"))
            {
                DriverManager.Current = Driver.GetForRemout();
                DriverManager.Current.OpenUrl(ConfigurationManager.AppSettings["RemoteUrl"]);
            }
            else
            {
                DriverManager.Current = Driver.GetFor(BrowserType.Chrome);
                DriverManager.Current.OpenUrl(ConfigurationManager.AppSettings["LocalUrl"]);
            }

            DriverManager.Current.MaximizeWindow();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Screenshot screen = ((ITakesScreenshot)DriverManager.Current.GetDriver()).GetScreenshot();
                var path = Path.Combine(TestContext.CurrentContext.WorkDirectory);
                screen.SaveAsFile(Path.Combine(path, "Fail.png"), ScreenshotImageFormat.Png);
            }

            DriverManager.Current.Quit();
        }
    }
}