using Newtonsoft.Json;

namespace dev.budget.Models
{
    public class UserTO
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}