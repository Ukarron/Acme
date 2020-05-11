using Acme.Framework.Core.Rest;
using Acme.UI;
using Allure.Commons;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
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
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Screenshot screen = ((ITakesScreenshot)DriverManager.Current.GetDriver()).GetScreenshot();
                var path = Path.Combine(TestContext.CurrentContext.WorkDirectory);
                screen.SaveAsFile(Path.Combine(TestContext.CurrentContext.WorkDirectory, "Image.png"), ScreenshotImageFormat.Png);
            }

            DriverManager.Current.Quit();
        }
    }
}