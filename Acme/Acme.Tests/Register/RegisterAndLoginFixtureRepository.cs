using Newtonsoft.Json;

namespace Acme.Test.Register
{
    public class RegisterAndLoginFixtureRepository : BaseFixtureRepository
    {
        [JsonProperty("registerResource")]
        public string RegisterResource { get; set; }

        [JsonProperty("loginResource")]
        public string LoginResource { get; set; }

        [JsonProperty]
        public string Email { get; set; }

        [JsonProperty]
        public string Password { get; set; }
    }
}