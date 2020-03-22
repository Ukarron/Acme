using Newtonsoft.Json;

namespace Acme.Test.Login
{
    public class LoginFixtureRepository : BaseFixtureRepository
    {
        [JsonProperty("loginResource")]
        public string LoginResource { get; set; }
    }
}