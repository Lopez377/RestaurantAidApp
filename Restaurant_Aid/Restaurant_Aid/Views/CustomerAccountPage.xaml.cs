using Restaurant_Aid.Model;
using Restaurant_Aid.Services;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Restaurant_Aid.Views
{
    public partial class CustomerAccountPage : ContentPage
    {
        private ApiService apiService;
        private ObservableCollection<string> orders;
        public CustomerAccountPage()
        {
            InitializeComponent();
            apiService = new ApiService();
            orders = new ObservableCollection<string>();
            orderListView.ItemsSource = orders;
        }

        protected override async void OnAppearing()
        {
            if (orders.Count == 0)
            {
                foreach (Order order in await apiService.GetOrdersForProfile(App.pid))
                {
                    if (!orders.Contains(order.oid.ToString()))
                    {
                        orders.Add(order.oid.ToString());
                    }
                }
            }
        }

        public async void goToOrderInfo(object sender, EventArgs e)
        {
            string oid = (string)((ListView)sender).SelectedItem;
            await Navigation.PushAsync(new OrderInfoPage(oid));
        }
    }
}
