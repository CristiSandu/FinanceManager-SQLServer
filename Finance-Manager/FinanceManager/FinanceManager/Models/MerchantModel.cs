using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Models
{
    public class MerchantModel
    {
        [JsonProperty("merchantId")]
        public int MerchantId { get; set; }

        [JsonProperty("merchantName")]
        public string MerchantName { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("merchantDescription")]
        public string MerchantDescription { get; set; }

        [JsonProperty("timeStamp")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty("category")]
        public Categorie Category { get; set; }

        [JsonProperty("transactionAccs")]
        public List<Transaction> TransactionAccs { get; set; }
    }
}
