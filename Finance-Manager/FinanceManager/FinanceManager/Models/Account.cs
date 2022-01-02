using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SQLite;

namespace FinanceManager.Models
{
    public class Account
    {
        [PrimaryKey, AutoIncrement]
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Bank { get; set; }
        public float Balance { get; set; }
        public string Type { get; set; }
        public string IBAN { get; set; }
        public string Titlular { get; set; }
    }
}
