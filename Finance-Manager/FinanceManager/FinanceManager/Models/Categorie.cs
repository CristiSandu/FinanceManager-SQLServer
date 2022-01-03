using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Models
{
    public class Categorie
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Icon { get; set; }
        public DateTime TimeStamp { get; set; }
        public List<object> Merchants { get; set; }
        public List<object> TransactionAccs { get; set; }
    }
}
