using Microcharts;
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
        public float Incomes { get; set; }

        [JsonProperty(PropertyName = "expences")]
        public float Expences { get; set; }

        [JsonProperty(PropertyName = "timeStamp")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty(PropertyName = "account")]
        public object Account { get; set; }

        [JsonProperty(PropertyName = "types")]
        public object Types { get; set; }

        public Chart ChartGen => Services.ChartGenerator.GerateIncomExpChart(Incomes, Expences);
        public string Month => StatsDate.ToString("MMM");

        public string DateView => StatsDate.ToString("MMMM yyyy");
        public float BalanceIncOut => Incomes - Expences;

        public float ExpencesView => Expences * -1;
    }
}
