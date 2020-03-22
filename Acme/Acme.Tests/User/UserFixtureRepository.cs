using Newtonsoft.Json;

namespace Acme.Test.Demo
{
    public class UserFixtureRepository : BaseFixtureRepository
    {
        [JsonProperty("usersResource")]
        public string UsersResource { get; set; }        
    }
}