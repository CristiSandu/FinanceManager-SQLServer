﻿using FinanceManager.Models;
using FinanceManager.Views.AccountViews;
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
        public float TotalBalance { get; set; }


        public AccountsPage()
        {
            InitializeComponent();
            Task.Run(async () =>
            {
               var accountList = await Services.APIConnection.GetCollection<Models.Account>("/api/Account");
                TotalBalance = accountList.Sum(x => x.AccountBalance);
                AccountsList = new ObservableCollection<Models.Account>(accountList);
            }).Wait();

            BindingContext = this;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            TotalBalance = AccountsList.Sum(x => x.AccountBalance);
        }

        private async void accountsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 0)
                return;

            var account = e.CurrentSelection.FirstOrDefault() as Account;

            await Navigation.PushAsync(new TransactionsPage());

            ((CollectionView)sender).SelectedItem = null;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var account = button.BindingContext as Models.Account;

            await Navigation.PushAsync(new AddTransactionPage(account));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddAccountPage());
        }
    }
}