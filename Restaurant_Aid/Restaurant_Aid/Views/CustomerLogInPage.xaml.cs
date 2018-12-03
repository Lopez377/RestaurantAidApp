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

        public async void logInSubmit(object sender, EventArgs e)
        {
            Debug.WriteLine("Logging In!");
            Profile p = await apiService.GetProfile(usernameEntry.Text);
            if(p.passhash != passwordEntry.Text)
            {
                DisplayAlert("ERROR", "Incorrect Password!", "Ok");
            }
            else
            {
                await Navigation.PushAsync(new CustomerPage());
            }
        }

        public async void registerAccountName(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccountCreationPage());
        }
    }
}
