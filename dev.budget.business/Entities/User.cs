using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace dev.budget.business.Entities
{
    public class User
    {
        [Key]
        [Column("person_id")]
        [JsonProperty("person_id")]
        public int PersonId { get; set; }

        [Column("username")]
        [JsonProperty("username")]
        public string Username { get; set; }

        [Column("password")]
        [JsonProperty("password")]
        public string Password { get; set; }

        public Person Person { get; set; }
    }
}
