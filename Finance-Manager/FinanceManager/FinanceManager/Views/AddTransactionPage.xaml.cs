using FinanceManager.Models;
using FinanceManager.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTransactionPage : ContentPage
    {
        public List<Account> Accounts { get; set; }

        public List<Categorie> Categorys { get; set; } 
        public List<string> Types { get; set; } = new List<string>
        {
            "Income",
            "Expense",
        };

        public string Name { get; set; }
        public string Description { get; set; }
        public float? Price { get; set; } = null;
        public DateTime Date { get; set; } = DateTime.Now;

        public AccountInfoExt SelectedAccount { get; set; }
        public Categorie SelectedCategory { get; set; }
        public string SelectedTypes { get; set; }

        public AddTransactionPage()
        {
            InitializeComponent();
            Task.Run(async () =>
            {
                Accounts = await Services.APIConnection.GetCollection<Models.Account>("/api/Account");
                Categorys = await Services.APIConnection.GetCollection<Models.Categorie>("/api/Categorie");
                SelectedAccount = new AccountInfoExt();
            }).Wait();
            BindingContext = this;
        }

        public AddTransactionPage(AccountInfoExt account)
        {
            InitializeComponent();
            Task.Run(async () =>
            {
                Accounts = await Services.APIConnection.GetCollection<Models.Account>("/api/Account");
                Categorys = await Services.APIConnection.GetCollection<Models.Categorie>("/api/Categorie");
                SelectedAccount = account;
            }).Wait();
            
            accountPicker.SelectedIndex = account.AccountId - 1;
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            accountPicker.SelectedIndex = SelectedAccount.AccountId - 1;
        }

        private async void SaveBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

        }

        private async void CancelBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}