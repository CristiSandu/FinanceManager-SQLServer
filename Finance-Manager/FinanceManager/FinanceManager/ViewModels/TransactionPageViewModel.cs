using FinanceManager.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Text;
using FinanceManager.Models.TransactionModels;

using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;
using FinanceManager.Views.AccountViews;
using System.Linq;

namespace FinanceManager.ViewModels
{
    public class TransactionPageViewModel : BaseViewModel
    {
        public ObservableCollection<TransactionGroupModel> TransationList { get; set; }
        public TransactionInfoExt SelectedTransaction { get; set; }
        public AccountInfoExt AccountInfo { get; set; }
        public ICommand GoToStats { get; set; }

        public Command<TransactionInfoExt> Delete { get; private set; }

        public TransactionPageViewModel(AccountInfoExt accountInfoExt)
        {
            GetData(accountInfoExt);

             GoToStats = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new StatsPerAccountPage(AccountInfo));
            });

            Delete = new Command<TransactionInfoExt>(async trans =>
            {
                if (await Services.APIConnection.DeleteCollectionElement<TransactionInfoExt>("/api/TransactionAcc/", trans.TransactionId))
                {
                    GetData(accountInfoExt);
                    AccountInfo.AccountBalance -= trans.ShowPrice ;
                    OnPropertyChanged(nameof(AccountInfo));
                }
            });
        }

        public ObservableCollection<TransactionGroupModel> GroupByIfEnded(List<TransactionInfoExt> trans)
        {
            var output = trans.GroupBy(tran => tran.TransactionDate)
                              .Select(tran => new { Name = tran.Key, Trans = tran.ToList() }).ToList();

            ObservableCollection<TransactionGroupModel> collection = new ObservableCollection<TransactionGroupModel>();

            var output2 = output.OrderByDescending(task => task.Name).ToList();
            output2.ForEach(group =>
            {
                collection.Add(new TransactionGroupModel(group.Name.ToString("dd.MM.yyyy"), group.Trans));
            });

            return collection;
        }

        public async void GetData(AccountInfoExt accountInfoExt)
        {
            var listOfTransactions = await Services.APIConnection.GetCollection<TransactionInfoExt>($"/api/TransactionAcc/GetTransactionForAnAccount/{accountInfoExt.AccountId}");
            TransationList = GroupByIfEnded(listOfTransactions);
            AccountInfo = accountInfoExt;

            OnPropertyChanged(nameof(TransationList));
            OnPropertyChanged(nameof(AccountInfo));

        }
    }
}
