using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceManager.Views.AccountViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionsPage : ContentPage
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

        public TransactionsPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new StatsPerAccountPage());
        }
    }
}