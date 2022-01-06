namespace FinanceManagerAPI.Models
{
    public class GroupDateTransactionCategoryModel
    {
        public DateTime? DateGoup { get; set; }
        public List<GroupByCategotyModel> CategoryTransaction { get; set;}
    }
}
