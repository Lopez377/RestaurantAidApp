using Restaurant_Aid.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Restaurant_Aid.Views
{
    public partial class AccountCreationPage : ContentPage
    {
        private ApiService apiService;
        public AccountCreationPage()
        {
            InitializeComponent();
            apiService = new ApiService();
        }

        public async void submitProfile(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("username", usernameEntry.Text));
            formData.Add(new KeyValuePair<string, string>("passhash", passwordEntry.Text));
            formData.Add(new KeyValuePair<string, string>("email", emailEntry.Text));
            formData.Add(new KeyValuePair<string, string>("dob", dobEntry.Text));
            if (await apiService.createProfile(formData))
            {
                await DisplayAlert("SUCCESS!", "Your account has been created!", "Ok!");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("ERROR!", "Your account failed to be created!", "Ok");
            }

        }
    }
}
