using Newtonsoft.Json;

namespace Acme.Test.Register
{
    public class RegisterFixtureRepository : BaseFixtureRepository
    {
        [JsonProperty("registerResource")]
        public string RegisterResource { get; set; }
    }
}
