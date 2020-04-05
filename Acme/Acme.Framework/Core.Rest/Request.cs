using Allure.NUnit.Attributes;
using RestSharp;

namespace Acme.Framework.Core.Rest
{
    public sealed class Request
    {
        internal RestRequest Wrapper;

        public Request(string resource, Method method)
        {
            Wrapper = new RestRequest(resource, method);
        }

        [AllureStep]
        public void AddParameter(string name, object value)
        {
            Wrapper.AddParameter(name, value);
        }
    }
}