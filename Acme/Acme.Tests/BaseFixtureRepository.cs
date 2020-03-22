using Newtonsoft.Json;

namespace Acme.Test
{
    public abstract class BaseFixtureRepository
    {
        [JsonProperty("baseUrl")]
        public string BaseUrl { get; set; }
    }
}