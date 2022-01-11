using FinanceManager.Models;
using FinanceManager.Models.AccountModels;
using FinanceManager.Models.TransactionModels;
using Microcharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FinanceManager.ViewModels
{
    public class StatsPerAccountPageViewModel : BaseViewModel
    {
        public ObservableCollection<Models.StatisticsModel> Statistics { get; set; }
        public ObservableCollection<Models.TransactionModels.TransactionByDateBase> TransactionsByCategory { get; set; }


        public Models.Type SelectedType { set; get; } = new Models.Type { TypesId = 6 };
        public StatisticsModel SelectedStatistic { get; set; }

        public TransactionByDateBase TransactionByDateBase { get; set; }

        public List<Chart> Charts { get; set; }

        public AccountInfoExt AccountInfo { get; set; }
        public ICommand GetStatFromApi { get; set; }
        public ICommand SelectedChartChange { get; set; }

        public StatsPerAccountPageViewModel(AccountInfoExt account)
        {
            AccountInfo = account;

            Task.Run(async() =>
            {
                var listOfStats = await Services.APIConnection.GetCollection<StatisticsModel>($"/api/Stats/GetStatsForAPeriod?type_id={SelectedType.TypesId}&account_id={account.AccountId}&endDate={DateTime.Now.ToString("yyyy-MM-dd")}&how_manny={6}");

                SelectedStatistic = listOfStats[0];
                Statistics = new ObservableCollection<StatisticsModel>(listOfStats);
                var categoryTransactions = await Services.APIConnection.GetCollection<TransactionByDateBase>($"/api/TransactionAcc/GroupTransactionsByCategorys?id_account={account.AccountId}&statType={'M'}");
                TransactionsByCategory = new ObservableCollection<TransactionByDateBase>(categoryTransactions);

                TransactionByDateBase = categoryTransactions[0];
                OnPropertyChanged(nameof(Statistics));
            }).Wait();

            GetStatFromApi = new Command(async () =>
            {
                var listOfStats = await Services.APIConnection.GetCollection<StatisticsModel>($"/api/Stats/GetStatsForAPeriod?type_id={SelectedType.TypesId}&account_id={account.AccountId}&endDate={DateTime.Now.ToString("yyyy-MM-dd")}&how_manny={6}");


                Statistics = new ObservableCollection<StatisticsModel>(listOfStats);
                var categoryTransactions = await Services.APIConnection.GetCollection<TransactionByDateBase>($"/api/TransactionAcc/GroupTransactionsByCategorys?id_account={account.AccountId}&statType={'M'}");
                TransactionsByCategory = new ObservableCollection<TransactionByDateBase>(categoryTransactions);
                TransactionByDateBase = categoryTransactions[0];
                
                OnPropertyChanged(nameof(TransactionsByCategory));
                OnPropertyChanged(nameof(Statistics));
            });

            SelectedChartChange = new Command(async () =>
            {
                List<TransactionByDateBase> transaction_date = TransactionsByCategory.Where(x => x.DateGoup == SelectedStatistic.StatsDate).ToList();
                TransactionByDateBase = transaction_date[0];
                OnPropertyChanged(nameof(SelectedStatistic));
                OnPropertyChanged(nameof(TransactionByDateBase));
            });

            int i = 0;
        }
    }
}
