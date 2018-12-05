using Restaurant_Aid.Model;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using Restaurant_Aid.Services;

namespace Restaurant_Aid.Views
{
    public partial class RestaurantAccountEditPage : ContentPage
    {
        private Restaurant r;
        private ApiService apiService;

        public RestaurantAccountEditPage(Restaurant r_)
        {
            InitializeComponent();
            r = r_;
            Name.Text = r.name;
            Phone.Text = r.phone;
            Address.Text = r.address;
            apiService = new ApiService();
        }

        public async void submitChanges(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("name", Name.Text));
            formData.Add(new KeyValuePair<string, string>("phone", Phone.Text));
            formData.Add(new KeyValuePair<string, string>("address", Address.Text));
            if (await apiService.editRestaurant(r.id.ToString(), formData))
            {
                await DisplayAlert("SUCCESS!", "Your account has been edited!", "Ok!");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("ERROR!", "Your account failed to be edited!", "Ok");
            }
        }
    }
}
