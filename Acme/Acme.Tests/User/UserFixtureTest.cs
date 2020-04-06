using Acme.Framework.Core.Rest;
using Acme.Test.Demo;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestSharp;

namespace Acme.Test.User
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("API")]
    public sealed class UserFixtureTest : BaseFixture<UserFixtureRepository>
    {
        protected override string FixtureTestDataPath => $"User\\{GetType().Name}Data.json";

        [Test]
        [AllureTag("User resource")]
        public void GetListUsersTest()
        {
            var usersRequest = new Request(Repository.UsersResource, Method.GET);
            var usersResponse = Client.Execute(usersRequest);
            Assert.AreEqual(200, (int)usersResponse.StatusCode);
        }

        [Test]
        [AllureTag("User resource")]
        public void GetSingleUserTest()
        {
            var resource = Repository.UsersResource + "/2";
            var usersRequest = new Request(resource, Method.GET);
            var usersResponse = Client.Execute(usersRequest);
            Assert.AreEqual(200, (int)usersResponse.StatusCode);
        }

        [Test]
        [AllureTag("User resource")]
        public void SingleUserNotFoundTest()
        {
            var resource = Repository.UsersResource + "/23";
            var usersRequest = new Request(resource, Method.GET);
            var usersResponse = Client.Execute(usersRequest);
            Assert.AreEqual(404, (int)usersResponse.StatusCode);
        }

        [Test]
        [AllureTag("User resource")]
        public void CreateTest()
        {
            var usersRequest = new Request(Repository.UsersResource, Method.POST);            
            usersRequest.AddParameter("name", Repository.Name);
            usersRequest.AddParameter("job", Repository.Job = "leader");
            var usersResponse = Client.Execute(usersRequest);
            Assert.AreEqual(201, (int)usersResponse.StatusCode);
        }

        [Test]
        [AllureTag("User resource")]
        public void PutTest()
        {
            var usersRequest = new Request(Repository.UsersResource + "/2", Method.PUT);
            usersRequest.AddParameter("name", Repository.Name);
            usersRequest.AddParameter("job", Repository.Job = "zion resident");
            var usersResponse = Client.Execute(usersRequest);
            Assert.AreEqual(200, (int)usersResponse.StatusCode);
        }

        [Test]
        [AllureTag("User resource")]
        public void PatchTest()
        {
            var usersRequest = new Request(Repository.UsersResource + "/2", Method.PATCH);
            usersRequest.AddParameter("name", Repository.Name);
            usersRequest.AddParameter("job", Repository.Job = "zion resident");
            var usersResponse = Client.Execute(usersRequest);
            Assert.AreEqual(200, (int)usersResponse.StatusCode);
        }

        [Test]
        [AllureTag("User resource")]
        public void DeleteTest()
        {
            var resource = Repository.UsersResource + "/2";
            var usersRequest = new Request(resource, Method.DELETE);
            var usersResponse = Client.Execute(usersRequest);
            Assert.AreEqual(204, (int)usersResponse.StatusCode);
        }
    }
}
