using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Models.StatsModels
{
    public class SmallStat
    {
        [JsonProperty(PropertyName = "totalBalance")]
        public decimal TotalBalance { get; set; }
        [JsonProperty(PropertyName = "numberExpences")]
        public int? NumberExpences { get; set; }
        [JsonProperty(PropertyName = "numberIncoms")]
        public int? NumberIncoms { get; set; }
        [JsonProperty(PropertyName = "numberCards")]
        public int NumberCards { get; set; }
        [JsonProperty(PropertyName = "numberBanks")]
        public int NumberBanks { get; set; }
    }
}
