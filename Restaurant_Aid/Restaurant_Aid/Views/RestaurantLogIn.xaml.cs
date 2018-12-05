using System;
using Xamarin.Forms;

namespace Restaurant_Aid.Views
{
    public partial class RestaurantLogIn : ContentPage
    {
        public RestaurantLogIn()
        {
            InitializeComponent();
        }

        public async void registerAccountName(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RestaurantCreationPage());
        }
    }
}
