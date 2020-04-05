using Acme.Framework.Core.Rest;
using Acme.Test.Register;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using RestSharp;

namespace Acme.Test.Login
{
    [TestFixture]
    [AllureSuite("API")]
    public sealed class LoginFixtureTest : BaseFixture<RegisterAndLoginFixtureRepository>
    {
        protected override string FixtureTestDataPath => "Register\\RegisterAndLoginFixtureTestData.json";

        [Test]
        public void LoginSuccessfulTest()
        {
            var usersRequest = new Request(Repository.LoginResource, Method.POST);
            usersRequest.AddParameter("email", Repository.Email = "eve.holt@reqres.in");
            usersRequest.AddParameter("password", Repository.Password =  "cityslicka");
            var usersResponse = Client.Execute(usersRequest);
            Assert.AreEqual(200, (int)usersResponse.StatusCode);
        }

        [Test]
        public void LoginUnsuccessfulTest()
        {
            var usersRequest = new Request(Repository.LoginResource, Method.POST);
            usersRequest.AddParameter("email", Repository.Email = "peter@klaven");
            var usersResponse = Client.Execute(usersRequest);
            Assert.AreEqual(400, (int)usersResponse.StatusCode);
        }
    }
}
