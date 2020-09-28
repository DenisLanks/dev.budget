using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace dev.budget.business.Entities
{
    [Table("addresses")]
    public class Address
    {
        [Column("id")]
        [JsonProperty("id")]
        public int Id { get; set; }
        [Column("postal_code")]
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
        [Column("name")]
        [JsonProperty("name")]
        public string Name { get; set; }
        [Column("number")]
        [JsonProperty("number")]
        public string Number { get; set; }
        [Column("state")]
        [JsonProperty("state")]
        public string State { get; set; }
        [Column("city")]
        [JsonProperty("city")]
        public string City { get; set; }
        [Column("complement")]
        [JsonProperty("complement")]
        public string Complement { get; set; }
    }
}
