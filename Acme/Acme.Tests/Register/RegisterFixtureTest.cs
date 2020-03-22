using Acme.Framework.Core.Rest;
using NUnit.Framework;
using RestSharp;

namespace Acme.Test.Register
{
    [TestFixture]
    public sealed class RegisterFixtureTest : BaseFixture<RegisterFixtureRepository>
    {
        protected override string FixtureTestDataPath => $"Register\\{GetType().Name}Data.json";

        [Test]
        public void RegisterSuccessfulTest()
        {
            var usersRequest = new Request(Repository.RegisterResource, Method.POST);
            usersRequest.AddParameter("email", "eve.holt@reqres.in");
            usersRequest.AddParameter("password", "pistol");
            var usersResponse = Client.Execute(usersRequest);
            Assert.AreEqual(200, (int)usersResponse.StatusCode);
        }

        [Test]
        public void RegisterUnsuccessfulTest()
        {
            var usersRequest = new Request(Repository.RegisterResource, Method.POST);
            usersRequest.AddParameter("email", "sydney@fife");
            var usersResponse = Client.Execute(usersRequest);
            Assert.AreEqual(400, (int)usersResponse.StatusCode);
        }
    }
}
