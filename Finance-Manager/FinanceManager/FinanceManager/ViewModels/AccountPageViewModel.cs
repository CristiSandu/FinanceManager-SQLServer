using FinanceManager.Models.AccountModels;
using FinanceManager.Models.StatsModels;
using FinanceManager.Views.AccountViews;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FinanceManager.ViewModels
{
    public class AccountPageViewModel : BaseViewModel
    {
        public ObservableCollection<AccountInfoExt> AccountsList { get; set; }
        public AccountInfoExt SelectedAccount { get; set; }

        public SmallStat SmallStats { get; set; }

        public ICommand AccountSelectedCommand { get; set; }
        
        public ICommand OpenPopUpInfo { get; set; }
        public Command<AccountInfoExt> Delete { get; private set; }


        public AccountPageViewModel()
        {
            Task.Run(async () =>
           {
               var listOfAccounts = await Services.APIConnection.GetCollection<AccountInfoExt>("/api/Account/AccountsInfoExt");
               var small_stats= await Services.APIConnection.GetCollection<SmallStat>("/api/Stats/GetSmallStats");

               AccountsList = new ObservableCollection<AccountInfoExt>(listOfAccounts);
               SmallStats = small_stats[0];
           }).Wait();

            AccountSelectedCommand = new Command(async () =>
            {
                if (SelectedAccount != null)
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new TransactionsPage(SelectedAccount));
                    SelectedAccount = null;
                    OnPropertyChanged(nameof(SelectedAccount));
                }
            });

            Delete = new Command<AccountInfoExt>(async acc =>
            {
                if (await Services.APIConnection.DeleteCollectionElement<AccountInfoExt>("/api/Account/", acc.AccountId))
                {
                    AccountsList.Remove(acc);
                    var small_stats = await Services.APIConnection.GetCollection<SmallStat>("/api/Stats/GetSmallStats");
                    SmallStats = small_stats[0];
                    OnPropertyChanged(nameof(SmallStats));
                }
            });

            OpenPopUpInfo = new Command(async () =>
            {
                await PopupNavigation.Instance.PushAsync(new Views.PopUps.SmallStatisticsPopUp { BindingContext = SmallStats });
            });
        }
    }
}
