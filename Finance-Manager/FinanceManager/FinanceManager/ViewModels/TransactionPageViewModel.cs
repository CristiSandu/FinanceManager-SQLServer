using FinanceManager.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Text;
using FinanceManager.Models.TransactionModels;

using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FinanceManager.ViewModels
{
    public class TransactionPageViewModel : BaseViewModel
    {
        public ObservableCollection<TransactionInfoExt> TransationList { get; set; }
        public TransactionInfoExt SelectedTransaction { get; set; }
        public AccountInfoExt AccountInfo { get; set; }
        public TransactionPageViewModel(AccountInfoExt accountInfoExt)
        {
            Task.Run(async () =>
            {
                var listOfAccounts = await Services.APIConnection.GetCollection<TransactionInfoExt>($"/api/TransactionAcc/GetTransactionForAnAccount/{accountInfoExt.AccountId}");
                TransationList = new ObservableCollection<TransactionInfoExt>(listOfAccounts);
                AccountInfo = accountInfoExt;
            }).Wait();
        }
    }
}
