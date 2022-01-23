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
        public AddTransactionPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.AddTransactionPageViewModel();
        }

        public AddTransactionPage(AccountInfoExt account)
        {
            InitializeComponent();
            BindingContext = new ViewModels.AddTransactionPageViewModel(account);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
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