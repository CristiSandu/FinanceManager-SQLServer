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
using Rg.Plugins.Popup.Services;

namespace FinanceManager.ViewModels
{
    public class TransactionPageViewModel : BaseViewModel
    {
        public ObservableCollection<TransactionGroupModel> TransationList { get; set; }
        private TransactionInfoExt _selectedTransaction { get; set; }
        public TransactionInfoExt SelectedTransaction {
            get
            {
                return _selectedTransaction;
            }
            set 
            { 
                if (_selectedTransaction != value)
                {
                    _selectedTransaction = value;
                    OpenPopup.Execute(_selectedTransaction);
                }
            } 
        }


        public AccountInfoExt AccountInfo { get; set; }
        public ICommand GoToStats { get; set; }
        public ICommand OpenPopup { get; set; }
        public ICommand AddTransaction { get; set; }



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

            OpenPopup = new Command<TransactionInfoExt>(async (trans) =>
            {
                await PopupNavigation.Instance.PushAsync(new Views.PopUps.TransactionPopUp { BindingContext = trans });
            });

            AddTransaction = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new Views.AddTransactionPage(AccountInfo));
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
