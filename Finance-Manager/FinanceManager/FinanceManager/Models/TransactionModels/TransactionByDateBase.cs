using System;
using System.Collections.Generic;

namespace FinanceManager.Models.TransactionModels
{
    public class TransactionByDateBase
    {
        public DateTime dateGoup { get; set; }
        public List<CategoryTransaction> categortyTransaction { get; set; }
    }
}