using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Models.TransactionModels
{
    public class CategoryTransaction
    {
        [JsonProperty("categotyName")]
        public string CategotyName { get; set; }

        [JsonProperty("totalSum")]
        public int TotalSum { get; set; }

        [JsonProperty("transactionsList")]
        public List<TransactionInfoExt> TransactionsList { get; set; }



    }
}
