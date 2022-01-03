using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using SQLite;

namespace FinanceManager.Models
{
    public class Account
    {
        [JsonProperty(PropertyName = "accountId")]
        public int AccountId { get; set; }
        [JsonProperty(PropertyName = "accountName")]
        public string AccountName { get; set; }
        [JsonProperty(PropertyName = "typesId ")]

        public int TypesId { get; set; }

        [JsonProperty(PropertyName = "bankId")]
        public int BankId { get; set; }

        [JsonProperty(PropertyName = "accountBalance")]
        public float AccountBalance { get; set; }

        [JsonProperty(PropertyName = "accountIban")]
        public string AccountIban { get; set; }

        [JsonProperty(PropertyName = "timeStamp")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty(PropertyName = "accountHolder")]
        public string AccountHolder { get; set; }

        [JsonProperty(PropertyName = "bank")]
        public Bank Bank { get; set; }

        [JsonProperty(PropertyName = "types")]
        public Models.Type Types { get; set; }

        [JsonProperty(PropertyName = "stats")]
        public List<object> Stats { get; set; }

        [JsonProperty(PropertyName = "transactionAccs")]
        public List<object> TransactionAccs { get; set; }
    }
}
