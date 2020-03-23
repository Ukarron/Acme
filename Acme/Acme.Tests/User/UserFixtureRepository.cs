using Newtonsoft.Json;

namespace Acme.Test.Demo
{
    public class UserFixtureRepository : BaseFixtureRepository
    {
        [JsonProperty("usersResource")]
        public string UsersResource { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Job { get; set; }
    }
}