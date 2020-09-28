using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dev.budget.Models
{
    public class EnterpriseTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }
    }
}
