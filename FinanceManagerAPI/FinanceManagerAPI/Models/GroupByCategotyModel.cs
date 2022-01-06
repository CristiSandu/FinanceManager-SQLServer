using FinanceManagerAPI.Database;

namespace FinanceManagerAPI.Models
{
    public class GroupByCategotyModel
    {
        public string CategotyName { get; set; }

        public double TotalSum  => TransactionsList.Sum(t => t.TransactionPrice);
        public List<TransactionInfoExt> TransactionsList { get;set; }
    }
}
