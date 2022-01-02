using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SQLite;

namespace FinanceManager.Models
{
    public class Transaction
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public float Price { get; set; }
        public string AccountId { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public MerchantModel Merchant { get; set; }
        public string Description { get; set; }





    }
}
