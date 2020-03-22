using Newtonsoft.Json;

namespace Acme.Test.Unknown
{
    public class UnknownFixtureRepository : BaseFixtureRepository
    {
        [JsonProperty("unknownResource")]
        public string UnknownResource { get; set; }
    }
}
