using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace dev.budget.business.Entities
{
    [Table("people")]
    public class Person
    {
        [Column("id")]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Column("name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Column("last_name")]
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [Column("cpf")]
        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [Column("email")]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Column("phone")]
        [JsonProperty("phone")]
        public string Phone { get; set; }

        public User User { get; set; }

        public List<Budget> Budgets { get; set; }
        public List<PersonEnterprise> PersonEnterprise { get; set; }
        public List<PersonAddress> PeopleAddresses { get; set; }
    }
}
