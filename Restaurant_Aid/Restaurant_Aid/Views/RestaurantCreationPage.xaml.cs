using Restaurant_Aid.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Restaurant_Aid.Views
{
    public partial class RestaurantCreationPage : ContentPage
    {
        private ApiService apiService;
        public RestaurantCreationPage()
        {
            InitializeComponent();
            apiService = new ApiService();
        }

        public async void submitRestaurant(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("username", username.Text));
            formData.Add(new KeyValuePair<string, string>("passhash", password.Text));
            formData.Add(new KeyValuePair<string, string>("name", name.Text));
            formData.Add(new KeyValuePair<string, string>("address", address.Text));
            formData.Add(new KeyValuePair<string, string>("phone", phone.Text));
            formData.Add(new KeyValuePair<string, string>("gps_loc", ""));
            if (await apiService.createRestaurant(formData))
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
