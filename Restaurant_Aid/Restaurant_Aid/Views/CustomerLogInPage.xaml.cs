using Restaurant_Aid.Model;
using Restaurant_Aid.Services;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Restaurant_Aid.Views
{
    public partial class CustomerLogInPage : ContentPage
    {
        private ApiService apiService;

        public CustomerLogInPage()
        {
            InitializeComponent();
            apiService = new ApiService();
        }


        public async void registerAccountName(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccountCreationPage());
        }
    }
}
