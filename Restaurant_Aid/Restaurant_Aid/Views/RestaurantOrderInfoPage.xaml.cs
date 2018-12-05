using Restaurant_Aid.Model;
using Restaurant_Aid.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Restaurant_Aid.Views
{
    public partial class RestaurantOrderInfoPage : ContentPage
    {
        private string oid;
        private List<Order> orders;
        private ObservableCollection<RMenuItem> menuItems;
        private ApiService apiService;
        public RestaurantOrderInfoPage(string _oid)
        {
            InitializeComponent();
            oid = _oid;
            apiService = new ApiService();
            orders = new List<Order>();
            menuItems = new ObservableCollection<RMenuItem>();
            menuItemListView.ItemsSource = menuItems;
        }

        protected override async void OnAppearing()
        {
            orders = await apiService.GetSingleOrder(oid);
            idLabel.Text = "Order ID#: " + orders[0].oid.ToString();
            statusLabel.Text = "Status: " + orders[0].status;
            detailLabel.Text = "Details: " + orders[0].detail;
            List<RMenuItem> actualMenu = await apiService.GetMenu(App.rid);
            foreach (Order orderItem in orders)
            {
                menuItems.Add(actualMenu.Find(a => a.id == orderItem.mid));
            }
        }

        public async void updateStatus(object sender, EventArgs e)
        {
            string status = (string)((Button)sender).CommandParameter;
            List<KeyValuePair<string, string>> formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("status", status));
            if (await apiService.editOrderStatus(oid.ToString(), formData))
            {
                await DisplayAlert("SUCCESS!", "Order updated!", "Ok!");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("ERROR!", "Order update failed!", "Ok");
            }
        }

        public async void deleteOrder(object sender, EventArgs e)
        {
            if (await apiService.deleteOrder(oid.ToString()))
            {
                await DisplayAlert("SUCCESS!", "Order deleted!", "Ok!");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("ERROR!", "Order delete failed!", "Ok");
            }
        }
    }
}
