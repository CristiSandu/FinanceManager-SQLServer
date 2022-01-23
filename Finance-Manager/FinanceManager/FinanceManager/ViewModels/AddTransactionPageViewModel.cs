using FinanceManager.Models;
using FinanceManager.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FinanceManager.ViewModels
{
    public class AddTransactionPageViewModel : BaseViewModel
    {
        public List<Account> Accounts { get; set; }
        public List<Categorie> Categorys { get; set; }
        public List<Models.Type> Types { get; set; }

        public List<Models.MerchantModel> Merchents { get; set; }



        public Account SelectedAccount { get; set; }
        public Categorie SelectedCategory { get; set; }
        public Models.Type SelectedType { get; set; }
        public Models.MerchantModel SelectedMerchent { get; set; }



        public int SelectedIndex { get; set; }

        public Transaction Transaction { get; set; }

        public ICommand SaveCommand { get; set; }

        public AddTransactionPageViewModel()
        {
            GetInitialInfos(new AccountInfoExt());
        }

        public AddTransactionPageViewModel(AccountInfoExt account)
        {
            GetInitialInfos(account);
            SaveCommand = new Command(async () =>
            {
                Transaction.CategoryId = SelectedCategory.CategoryId;
                Transaction.AccountId = SelectedAccount.AccountId;
                Transaction.TypesId = SelectedType.TypesId;
                Transaction.MerchantId = SelectedMerchent.MerchantId;


                if (await Services.APIConnection.AddCollectionElement<Transaction>("/api/TransactionAcc", Transaction))
                {
                    await Application.Current.MainPage.DisplayActionSheet("Success", "Add Succesfully", "OK", "Cancel");
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await Application.Current.MainPage.DisplayPromptAsync("Error", "Error on add transaction", "OK", "Cancel");
                }
            });
        }

        public async void GetInitialInfos(AccountInfoExt account)
        {
            Accounts = await Services.APIConnection.GetCollection<Models.Account>("/api/Account");
            Categorys = await Services.APIConnection.GetCollection<Models.Categorie>("/api/Categorie");
            Types = await Services.APIConnection.GetCollection<Models.Type>($"/api/Type/TableName?tableName=Transaction");
            Merchents = await Services.APIConnection.GetCollection<Models.MerchantModel>("/api/Merchant");

            OnPropertyChanged(nameof(Accounts));
            OnPropertyChanged(nameof(Categorys));
            OnPropertyChanged(nameof(Types));
            OnPropertyChanged(nameof(Merchents));

            SelectedIndex = account.AccountId - 1;
            OnPropertyChanged(nameof(SelectedIndex));
            Transaction = new Transaction { TransactionDate = DateTime.Now, TimeStamp = DateTime.Now };
            Transaction.AccountId = account.AccountId;
        }

    }
}
