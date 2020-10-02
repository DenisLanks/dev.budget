using dev.budget.business.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dev.budget.Models
{
    public class BudgetTO
    {
        public BudgetTO()
        {

        }

        public BudgetTO(Budget budget)
        {
            this.DesCount = budget.DesignerCount;
            this.DevCount = budget.DevCount;
            this.Duration = budget.Duration;
            this.POCount = budget.POCount;
            this.SMCount = budget.SMCount;
        }
        [JsonProperty("dev_count")]
        public int DevCount { get; set; }
        [JsonProperty("design_count")]
        public int DesCount { get; set; }
        [JsonProperty("sm_count")]
        public int SMCount { get; set; }
        [JsonProperty("po_count")]
        public int POCount { get; set; }
        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

    }
}
