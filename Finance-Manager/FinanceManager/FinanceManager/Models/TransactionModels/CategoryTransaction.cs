using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Models.TransactionModels
{
    public class CategoryTransaction
    {
        public string categotyName { get; set; }
        public int totalSum { get; set; }
        public List<TransactionInfoExt> transactionsList { get; set; }
    }
}
