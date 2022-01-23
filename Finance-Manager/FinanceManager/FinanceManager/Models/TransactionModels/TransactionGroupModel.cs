using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Models.TransactionModels
{
    public class TransactionGroupModel : List<TransactionInfoExt>
    {
        public string Name { get; private set; }

        public TransactionGroupModel(string name, List<TransactionInfoExt> trans) : base(trans)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
