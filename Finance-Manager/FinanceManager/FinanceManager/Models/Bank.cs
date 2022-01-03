using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Models
{
    public class Bank
    {
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string BankDescription { get; set; }
        public byte[] Image { get; set; }
        public DateTime TimeStamp { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
