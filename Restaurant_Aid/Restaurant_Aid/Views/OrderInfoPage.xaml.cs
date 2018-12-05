using Restaurant_Aid.Model;
using Restaurant_Aid.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Restaurant_Aid.Views
{
    public partial class OrderInfoPage : ContentPage
    {
        private string oid;
        private string rid;
        private ApiService apiService;
        private Restaurant restaurant;
        private List<Order> order;
        private ObservableCollection<RMenuItem> menuItems;
        public OrderInfoPage(string _oid)
        {
            InitializeComponent();
            oid = _oid;
            apiService = new ApiService();
            menuItems = new ObservableCollection<RMenuItem>();
            menuItemListView.ItemsSource = menuItems;
        }

        protected override async void OnAppearing()
        {
            order = await apiService.GetSingleOrder(oid);
            rid = order[0].rid.ToString();
            restaurant = await apiService.GetSingleRestaurant(rid);
            restaurantName.Text = "Name: " + restaurant.name;
            List<RMenuItem> actualMenu = await apiService.GetMenu(Int32.Parse(rid));
            foreach(Order orderItem in order)
            {
                menuItems.Add(actualMenu.Find(a => a.id == orderItem.mid));
            }
        }

        public async void sendAlert(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("rid", rid));
            formData.Add(new KeyValuePair<string, string>("pid", App.pid.ToString()));
            formData.Add(new KeyValuePair<string, string>("status", "SENT"));
            formData.Add(new KeyValuePair<string, string>("detail", order[0].detail));
            if(await apiService.sendAlert(formData))
            {
                await Application.Current.MainPage.DisplayAlert("Success!", "Your alert has been sent!", "Ok!");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error!", "Please find your nearest server.", "Ok");
            }
        }
    }
}
