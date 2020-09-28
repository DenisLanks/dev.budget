using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dev.budget.Models
{
    public class AccountTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("address")]
        public AddressTO Address { get; set; }

        [JsonProperty("user")]
        public UserTO User { get; set; }

        [JsonProperty("enterprise")]
        public EnterpriseTO Enterprise { get; set; }
    }
}
