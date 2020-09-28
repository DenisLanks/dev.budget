using Newtonsoft.Json;

namespace dev.budget.Models
{
    public class AddressTO
    {
        [JsonProperty("postal_code")]
        public string Cep { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("number")]
        public string Number { get; set; }
        [JsonProperty("complement")]
        public string Complement { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
    }
}