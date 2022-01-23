using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using SQLite;

namespace FinanceManager.Models
{
    public class Transaction
    {
        [JsonProperty("transactionId")]
        public int TransactionId { get; set; }

        [JsonProperty("transactionName")]
        public string TransactionName { get; set; }

        [JsonProperty("typesId")]
        public int TypesId { get; set; }

        [JsonProperty("merchantId")]
        public int MerchantId { get; set; }

        [JsonProperty("accountId")]
        public int AccountId { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("transactionPrice")]
        public int TransactionPrice { get; set; }

        [JsonProperty("transactionDate")]
        public DateTime TransactionDate { get; set; }

        [JsonProperty("image")]
        public object Image { get; set; }

        [JsonProperty("transactionDescription")]
        public string TransactionDescription { get; set; }

        [JsonProperty("timeStamp")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty("account")]
        public object Account { get; set; }

        [JsonProperty("category")]
        public object Category { get; set; }

        [JsonProperty("merchant")]
        public object Merchant { get; set; }

        [JsonProperty("types")]
        public object Types { get; set; }

    }
}
