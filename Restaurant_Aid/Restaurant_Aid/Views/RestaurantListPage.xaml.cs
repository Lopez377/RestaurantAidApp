using Restaurant_Aid.Model;
using Restaurant_Aid.ViewModels;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Restaurant_Aid.Views
{
    public partial class RestaurantListPage : ContentPage
    {
        public RestaurantListPage()
        {
            InitializeComponent();
        }

        public async void goToRestaurantMenu(object sender, EventArgs e)
        {
            int rid = ((Restaurant)((ListView)sender).SelectedItem).id;
            string address = ((Restaurant)((ListView)sender).SelectedItem).address;
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(goToRestaurantMenu)}");

            await Navigation.PushAsync(new CustomerMenuPage(rid, address));
        }
    }
}
