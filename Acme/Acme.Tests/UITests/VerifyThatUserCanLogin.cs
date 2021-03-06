﻿using Acme.Test.Register;
using Acme.UI;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Acme.Test.UITests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("UI")]
    public class VerifyThatUserCanLogin : BaseFixture<RegisterAndLoginFixtureRepository>
    {
        protected override string FixtureTestDataPath => "Register\\RegisterAndLoginFixtureTestData.json";
        private const string EXPECTED_USERNAME = "ukarron";

        [Test]
        [AllureTag("Verify if user can login into the application")]
        public void VerifyThatUserCanLoginTest()
        {
            WordPressUA.LoginPage.Login(UrlManager.LoginPage(BaseUrl));

            WordPressUA.PersonalMenu.Expand();

            var actualUsername = WordPressUA.PersonalMenu.GetUsername();

            Assert.AreEqual(EXPECTED_USERNAME, actualUsername, $"Incorrect username, should be {0}, but was {1}",
                EXPECTED_USERNAME, actualUsername);
        }
    }
}
