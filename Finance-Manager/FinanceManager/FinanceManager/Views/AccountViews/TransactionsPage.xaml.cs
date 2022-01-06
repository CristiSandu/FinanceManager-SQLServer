using FinanceManager.Models.AccountModels;
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
        public TransactionsPage(AccountInfoExt accountInfoExt)
        {
            InitializeComponent();
            BindingContext = new ViewModels.TransactionPageViewModel(accountInfoExt);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new StatsPerAccountPage());
        }
    }
}