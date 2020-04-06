using RestSharp;
using System.Net;

namespace Acme.Framework.Core.Rest
{
    public sealed class Client
    {
        private readonly RestClient _wrapper;

        public Client(string url)
        {
            _wrapper = new RestClient(url);
            _wrapper.CookieContainer = new CookieContainer();
        }

        public IRestResponse Execute(Request request)
        {
            var response = _wrapper.Execute(request.Wrapper);
            return response;
        }
    }
}