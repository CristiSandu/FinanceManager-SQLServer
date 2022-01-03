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
    public partial class AccountsPage : ContentPage
    {
        public ObservableCollection<Models.Account> AccountsList { get; set; } = new ObservableCollection<Models.Account>
        {
            new Models.Account
            {
                AccountName = "BCR",
                AccountBalance = 2000
            },
            new Models.Account
            {
                AccountName = "BCR",
                AccountBalance = 2000
            },
            new Models.Account
            {
                AccountName = "BCR",
                AccountBalance = 2000
            },
            new Models.Account
            {
                AccountName = "BCR",
                AccountBalance = 2000
            },
             new Models.Account
            {
                AccountName = "BCR",
                AccountBalance = 2000
            }, new Models.Account
            {
                AccountName = "BCR",
                AccountBalance = 2000
            }, new Models.Account
            {
                AccountName = "BCR",
                AccountBalance = 2000
            }, new Models.Account
            {
                AccountName = "BCR",
                AccountBalance = 2000
            }, new Models.Account
            {
                AccountName = "BCR",
                AccountBalance = 2000
            }, new Models.Account
            {
                AccountName = "BCR",
                AccountBalance = 2000
            }, new Models.Account
            {
                AccountName = "BCR",
                AccountBalance = 2000
            }, new Models.Account
            {
                AccountName = "BCR",
                AccountBalance = 2000,

            }, new Models.Account
            {
                AccountName = "BCR",
                AccountBalance = 2000
            }, new Models.Account
            {
                AccountName = "BCR",
                AccountBalance = 2000
            }, new Models.Account
            {
                AccountName = "BCR",
                AccountBalance = 2000
            },
        };



        public AccountsPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

        }

        private void accountsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}