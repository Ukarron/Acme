using Acme.Framework.Core.Rest;
using NUnit.Framework;
using RestSharp;

namespace Acme.Test.Register
{
    [TestFixture]
    public sealed class RegisterFixtureTest : BaseFixture<RegisterAndLoginFixtureRepository>
    {
        protected override string FixtureTestDataPath => $"Register\\RegisterAndLoginFixtureTestData.json";

        [Test]
        public void RegisterSuccessfulTest()
        {
            var usersRequest = new Request(Repository.RegisterResource, Method.POST);
            usersRequest.AddParameter("email", Repository.Email = "eve.holt@reqres.in");
            usersRequest.AddParameter("password", Repository.Password = "pistol");
            var usersResponse = Client.Execute(usersRequest);
            Assert.AreEqual(200, (int)usersResponse.StatusCode);
        }

        [Test]
        public void RegisterUnsuccessfulTest()
        {
            var usersRequest = new Request(Repository.RegisterResource, Method.POST);
            usersRequest.AddParameter("email", Repository.Email = "sydney@fife");
            var usersResponse = Client.Execute(usersRequest);
            Assert.AreEqual(400, (int)usersResponse.StatusCode);
        }
    }
}
