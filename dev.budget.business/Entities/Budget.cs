using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace dev.budget.business.Entities
{
    [Table("budgets")]
    public class Budget
    {
        [Column("id")]
        [JsonProperty("id")]
        public int Id { get; set; }
        [Column("person_id")]
        [JsonProperty("person_id")]
        public int PersonId { get; set; }
        [Column("dev_count")]
        [JsonProperty("dev_count")]
        public int DevCount { get; set; }
        [Column("designer_count")]
        [JsonProperty("designer_count")]
        public int DesignerCount { get; set; }
        [Column("sm_count")]
        [JsonProperty("sm_count")]
        public int SMCount { get; set; }
        [Column("po_count")]
        [JsonProperty("po_count")]
        public int POCount { get; set; }
        [Column("duration")]
        [JsonProperty("duration")]
        public int Duration { get; set; }

        public Person Person { get; set; }
    }
}
