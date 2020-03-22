using Acme.Framework.Core.Rest;
using NUnit.Framework;
using RestSharp;

namespace Acme.Test.Login
{
    [TestFixture]
    public sealed class LoginFixtureTest : BaseFixture<LoginFixtureRepository>
    {
        protected override string FixtureTestDataPath => $"Login\\{GetType().Name}Data.json";

        [Test]
        public void LoginSuccessfulTest()
        {
            var usersRequest = new Request(Repository.LoginResource, Method.POST);
            usersRequest.AddParameter("email", "eve.holt@reqres.in");
            usersRequest.AddParameter("password", "cityslicka");
            var usersResponse = Client.Execute(usersRequest);
            Assert.AreEqual(200, (int)usersResponse.StatusCode);
        }

        [Test]
        public void LoginUnsuccessfulTest()
        {
            var usersRequest = new Request(Repository.LoginResource, Method.POST);
            usersRequest.AddParameter("email", "peter@klaven");
            var usersResponse = Client.Execute(usersRequest);
            Assert.AreEqual(400, (int)usersResponse.StatusCode);
        }
    }
}
