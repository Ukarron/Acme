using Acme.Framework.Core.Rest;
using NUnit.Framework;
using RestSharp;

namespace Acme.Test.Unknown
{
    [TestFixture]
    public sealed class UnknownFixtureTest : BaseFixture<UnknownFixtureRepository>
    {
        protected override string FixtureTestDataPath => $"Unknown\\{GetType().Name}Data.json";

        [Test]
        public void ListResourceTest()
        {
            var usersRequest = new Request(Repository.UnknownResource, Method.GET);
            var usersResponse = Client.Execute(usersRequest);
            Assert.AreEqual(200, (int)usersResponse.StatusCode);
        }

        [Test]
        public void SingleResourceTest()
        {
            var resource = Repository.UnknownResource + "/2";
            var usersRequest = new Request(resource, Method.GET);
            var usersResponse = Client.Execute(usersRequest);
            Assert.AreEqual(200, (int)usersResponse.StatusCode);
        }

        [Test]
        public void SingleResourceNotFoundTest()
        {
            var resource = Repository.UnknownResource + "/23";
            var usersRequest = new Request(resource, Method.GET);
            var usersResponse = Client.Execute(usersRequest);
            Assert.AreEqual(404, (int)usersResponse.StatusCode);
        }
    }
}
