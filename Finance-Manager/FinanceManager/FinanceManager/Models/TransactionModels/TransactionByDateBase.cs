using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FinanceManager.Models.TransactionModels
{
    public class TransactionByDateBase
    {
        [JsonProperty("dateGoup")]
        public DateTime DateGoup { get; set; }

        [JsonProperty("categoryTransaction")]
        public List<CategoryTransaction> CategoryTransaction { get; set; }

        public string CategoryName => CategoryTransaction.Count > 0 ? CategoryTransaction[0].CategotyName : string.Empty;
        public string TotalSum => CategoryTransaction.Count > 0 ? CategoryTransaction[0].TotalSum.ToString() : string.Empty;

    }
}