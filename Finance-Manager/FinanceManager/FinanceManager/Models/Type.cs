using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Models
{
    public class Type
    {
        public int TypesId { get; set; }
        public string TypesName { get; set; }
        public string TableName { get; set; }
        public List<Account> Accounts { get; set; }
        public List<object> Stats { get; set; }
        public List<object> TransactionAccs { get; set; }
    }
}
