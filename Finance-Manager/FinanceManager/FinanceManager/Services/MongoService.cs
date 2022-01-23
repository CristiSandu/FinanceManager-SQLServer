using FinanceManager.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace FinanceManager.Services
{
    public static class MongoService
    {
        static IMongoCollection<Transaction> todoItemsCollection;
        readonly static string dbName = "FinanceMg";
        readonly static string collectionName = "Transactions";
        static MongoClient client;
        static IMongoCollection<Transaction> ToDoItemsCollection
        {
            get
            {
                if (client == null || todoItemsCollection == null)
                {
                    string connectionString = @"mongodb://finance-manager:xmCFfuDYP9l38DgiNuiNg1DjatFV3gxz5LLoqHHWPrW9jiKMx2vHBaq2fMPPA5jJQuRbhyZkMgmoTG9DzvMxzg==@finance-manager.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@finance-manager@";
                    MongoClientSettings settings = MongoClientSettings.FromUrl(
                      new MongoUrl(connectionString)
                    );

                    settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };

                    client = new MongoClient(settings);
                    var db = client.GetDatabase(dbName);

                    var collectionSettings = new MongoCollectionSettings { ReadPreference = ReadPreference.Nearest };
                    todoItemsCollection = db.GetCollection<Transaction>(collectionName, collectionSettings);
                }

                return todoItemsCollection;
            }
        }

        public async static Task<List<Transaction>> GetAllItems()
        {
            var allItems = await ToDoItemsCollection.Aggregate().ToListAsync();
            return allItems;
        }

        public async static Task<List<Transaction>> SearchByName(string name)
        {
         
            return new List<Transaction>();
        }

        public async static Task InsertItem(Transaction item)
        {
            await ToDoItemsCollection.InsertOneAsync(item);
        }

        public async static Task<bool> DeleteItem(Transaction item)
        {
            var result = await ToDoItemsCollection.DeleteOneAsync(tdi => tdi.TransactionId == item.TransactionId);

            return result.IsAcknowledged && result.DeletedCount == 1;
        }
    }
}
