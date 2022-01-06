using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Models
{
    public class StatisticsModel
    {
        [JsonProperty(PropertyName = "statsId")]
        public int StatsId { get; set; }

        [JsonProperty(PropertyName = "statsDate")]
        public DateTime StatsDate { get; set; }

        [JsonProperty(PropertyName = "typesId")]
        public int TypesId { get; set; }

        [JsonProperty(PropertyName = "accountId")]
        public int AccountId { get; set; }

        [JsonProperty(PropertyName = "incomes")]
        public int Incomes { get; set; }

        [JsonProperty(PropertyName = "expences")]
        public int Expences { get; set; }

        [JsonProperty(PropertyName = "timeStamp")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty(PropertyName = "account")]
        public object Account { get; set; }

        [JsonProperty(PropertyName = "types")]
        public object Types { get; set; }
    }
}
