using FinanceManager.Models;
using FinanceManager.Models.AccountModels;
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
        public AccountsPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.AccountPageViewModel();
        }
      
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var account = button.BindingContext as AccountInfoExt;

            await Navigation.PushAsync(new AddTransactionPage(account));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddAccountPage());
        }
    }
}