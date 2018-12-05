using Restaurant_Aid.Model;
using Restaurant_Aid.Services;
using System;
using Xamarin.Forms;

namespace Restaurant_Aid.Views
{
    public partial class RestaurantAccountPage : ContentPage
    {
        private ApiService apiService;
        private Restaurant r;
        public RestaurantAccountPage()
        {
            InitializeComponent();
            apiService = new ApiService();
        }

        protected override async void OnAppearing()
        {
            r = await apiService.GetSingleRestaurant(App.rid.ToString());
            rid.Text = "Restaurant ID#: " + r.id.ToString();
            name.Text = "Name: " + r.name;
            username.Text = "Username: " + r.username;
            phone.Text = "Phone: " + r.phone;
            address.Text = "Address: " + r.address;
        }

        public async void editRestaurant(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RestaurantAccountEditPage(r));
        }
    }
}
