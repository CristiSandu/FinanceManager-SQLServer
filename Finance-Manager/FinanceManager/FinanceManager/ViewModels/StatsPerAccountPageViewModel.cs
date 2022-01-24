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
        public ICommand ChangePerMonthViewComm { get; set; }
        public ICommand ChangePerYearViewComm { get; set; }

        public int VerticalSpacingValue { get; set; } = 0;


        public StatsPerAccountPageViewModel(AccountInfoExt account)
        {
            AccountInfo = account;
            GetStatsBy('M', 6,SelectedType.TypesId);

            GetStatFromApi = new Command(async () =>
            {
                var listOfStats = await Services.APIConnection.GetCollection<StatisticsModel>($"/api/Stats/GetStatsForAPeriod?type_id={SelectedType.TypesId}&account_id={account.AccountId}&how_manny={6}");
                Statistics = new ObservableCollection<StatisticsModel>(listOfStats);
                
                var categoryTransactions = await Services.APIConnection.GetCollection<TransactionByDateBase>($"/api/TransactionAcc/GroupTransactionsByCategorys?id_account={account.AccountId}&statType={'M'}&size={6}");
                TransactionsByCategory = new ObservableCollection<TransactionByDateBase>(categoryTransactions);
                TransactionByDateBase = categoryTransactions[0];
                
                OnPropertyChanged(nameof(TransactionsByCategory));
                OnPropertyChanged(nameof(Statistics));
            });

            SelectedChartChange = new Command(async () =>
            {
                List<TransactionByDateBase> transaction_date = TransactionsByCategory.Where(x => x.DateGoup.Year == SelectedStatistic.StatsDate.Year && x.DateGoup.Month == SelectedStatistic.StatsDate.Month).ToList();
                if (transaction_date.Count >= 1 )
                    TransactionByDateBase = transaction_date[0];
                OnPropertyChanged(nameof(SelectedStatistic));
                OnPropertyChanged(nameof(TransactionByDateBase));
            });

            ChangePerMonthViewComm = new Command( () =>
            {
                GetStatsBy('M', 6, SelectedType.TypesId);
                VerticalSpacingValue = 0;
                OnPropertyChanged(nameof(VerticalSpacingValue));
            });

            ChangePerYearViewComm = new Command( () =>
            {
                GetStatsBy('Y', 3, 8);
                VerticalSpacingValue = 90;
                OnPropertyChanged(nameof(VerticalSpacingValue));    
            });
        }

        public async void GetStatsBy(char type_interval, int size, int type_id)
        {
            var listOfStats = await Services.APIConnection.GetCollection<StatisticsModel>($"/api/Stats/GetStatsForAPeriod?type_id={type_id}&account_id={AccountInfo.AccountId}&how_manny={size}");
            SelectedStatistic = listOfStats[0];
            Statistics = new ObservableCollection<StatisticsModel>(listOfStats);
            
            var categoryTransactions = await Services.APIConnection.GetCollection<TransactionByDateBase>($"/api/TransactionAcc/GroupTransactionsByCategorys?id_account={AccountInfo.AccountId}&statType={type_interval}&size={size}");
            TransactionsByCategory = new ObservableCollection<TransactionByDateBase>(categoryTransactions);
            TransactionByDateBase = categoryTransactions[0];
            
            OnPropertyChanged(nameof(Statistics));
            OnPropertyChanged(nameof(SelectedStatistic));
            OnPropertyChanged(nameof(TransactionsByCategory));
            OnPropertyChanged(nameof(TransactionByDateBase));
        }
    }
}
