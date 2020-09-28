using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace dev.budget.business.Entities
{
    [Table("enterprises")]
    public class Enterprise
    {
        [Column("id")]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Column("name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Column("cnpj")]
        [JsonProperty("cnpj")]
        public string CNPJ { get; set; }

        public List<PersonEnterprise> PersonEnterprise { get; set; }

    }
}
