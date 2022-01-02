using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Models
{
    public class TransactionsByModel
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Account Account { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public MerchantModel Merchant{ get; set; }
    }
}
