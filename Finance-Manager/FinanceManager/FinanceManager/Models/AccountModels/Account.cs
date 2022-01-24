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
        [JsonProperty("accountId")]
        public int AccountId { get; set; }

        [JsonProperty("accountName")]
        public string AccountName { get; set; }

        [JsonProperty("typesId")]
        public int TypesId { get; set; }

        [JsonProperty("bankId")]
        public int BankId { get; set; }

        [JsonProperty("accountBalance")]
        public float AccountBalance { get; set; }

        [JsonProperty("accountIban")]
        public string AccountIban { get; set; }

        [JsonProperty("timeStamp")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty("accountHolder")]
        public string AccountHolder { get; set; }

        [JsonProperty("bank")]
        public Bank Bank { get; set; }

        [JsonProperty("types")]
        public Models.Type Types { get; set; }

        [JsonProperty("stats")]
        public List<StatisticsModel> Stats { get; set; }

        [JsonProperty("transactionAccs")]
        public List<Transaction> TransactionAccs { get; set; }
    }
}
