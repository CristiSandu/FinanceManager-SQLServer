using FinanceManager.Models;
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
    public class AddAccountPageViewModel : BaseViewModel
    {
        public Account AccountData { get; set; } = new Account { AccountBalance = 0, TimeStamp = DateTime.Now, Stats = new List<StatisticsModel>(), TransactionAccs = new List<Transaction>() };
        public Account SelectedAccount { get; set; }

        public bool IsShowAddAccount { get; set; }
        public ObservableCollection<Account> Accounts { get; set; }
        public List<Account> accountList;

        public List<Bank> BanksList { get; set; }
        public List<Models.Type> TypesList { get; set; }

        public Bank SelectedBank { get; set; }
        public Models.Type SelectedType { get; set; }

        public int SelectedIndexBank { get;set; }
        public int SelectedIndexType{ get; set; }


        public ICommand AddNewAccount { get; set; }
        public ICommand ShowAddAccount { get; set; }
        public ICommand ShowForm{ get; set; }

        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteAccoutCommand { get; set; }

        public AddAccountPageViewModel()
        {
            Task.Run(async () =>
            {
                accountList = await Services.APIConnection.GetCollection<Account>("/api/Account");
                BanksList = await Services.APIConnection.GetCollection<Bank>("/api/Bank");
                TypesList = await Services.APIConnection.GetCollection<Models.Type>("/api/Type/TableName?tableName=Account");
           
                Accounts = new ObservableCollection<Account>(accountList);
            }).Wait();

            AddNewAccount = new Command(async () =>
            {
                if (AccountData.AccountName == null || AccountData.AccountName == "")
                {
                    await App.Current.MainPage.DisplayAlert("Alert!", "Fill all fields", "Ok");
                    return;
                }

                if (!Accounts.Any(x => x.AccountName == AccountData.AccountName))
                {

                    AccountData.TypesId = SelectedType.TypesId;
                    AccountData.BankId = SelectedBank.BankId;

                    if (await Services.APIConnection.AddCollectionElement<Account>("/api/Account", AccountData))
                    {
                        Accounts.Add(AccountData);
                        await App.Current.MainPage.DisplayAlert("Success!", "Account Added", "Ok");
                        return;
                    }

                    await App.Current.MainPage.DisplayAlert("Alert!", "Add Unsuccesfully, retry", "Ok");

                }
                else if (AccountData.AccountId != 0)
                {
                    if (await Services.APIConnection.UpdateCollectionElement<Account>("/api/Account", AccountData, AccountData.AccountId))
                    {
                        Accounts.Remove(SelectedAccount);
                        Accounts.Add(AccountData);

                        await App.Current.MainPage.DisplayAlert("Success!", "Account Added", "Ok");
                        return;
                    }
                    await App.Current.MainPage.DisplayAlert("Alert!", "Account Exist, try another Name", "Ok");
                }


                AccountData = new Account { AccountBalance = 0, TimeStamp = DateTime.Now, Stats = new List<StatisticsModel>(), TransactionAccs = new List<Transaction>() };
                OnPropertyChanged(nameof(AccountData));
            });

            UpdateCommand = new Command(() =>
            {
                ShowForm.Execute(true);
                SelectedIndexBank = SelectedAccount.BankId - 1;
                SelectedIndexType = SelectedAccount.TypesId - 3;
                AccountData = SelectedAccount;
                OnPropertyChanged(nameof(SelectedIndexBank));
                OnPropertyChanged(nameof(SelectedIndexType));
                OnPropertyChanged(nameof(AccountData));

            });

            DeleteAccoutCommand = new Command(async () =>
            {
                if (await Services.APIConnection.DeleteCollectionElement<Account>("/api/Account", AccountData.AccountId))
                {
                    Accounts.Remove(AccountData);
                    ShowAddAccount.Execute(AccountData);
                    OnPropertyChanged(nameof(AccountData));
                }
            });

            ShowAddAccount = new Command(() =>
            {
                ShowForm.Execute(true);
                SelectedIndexBank = -1;
                SelectedIndexType = -3;
                AccountData = new Account { AccountBalance = 0, TimeStamp = DateTime.Now, Stats = new List<StatisticsModel>(), TransactionAccs = new List<Transaction>() };
                OnPropertyChanged(nameof(SelectedIndexBank));
                OnPropertyChanged(nameof(SelectedIndexType));
                OnPropertyChanged(nameof(AccountData));
            });

            ShowForm = new Command<bool>((val) =>
            {
                IsShowAddAccount = val;
                OnPropertyChanged(nameof(IsShowAddAccount));
            });
        }
    }
}
