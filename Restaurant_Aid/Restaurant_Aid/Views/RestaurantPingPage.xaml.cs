using Restaurant_Aid.Model;
using Restaurant_Aid.Services;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Restaurant_Aid.Views
{
    public partial class RestaurantPingPage : ContentPage
    {
        private ApiService apiService;
        ObservableCollection<Alert> alerts;
        public RestaurantPingPage()
        {
            InitializeComponent();
            apiService = new ApiService();
            alerts = new ObservableCollection<Alert>();
            alertListView.ItemsSource = alerts;
        }

        protected override async void OnAppearing()
        {
            alerts.Clear();
            foreach (Alert a in await apiService.GetAlertsByRid(App.rid.ToString()))
            {
                alerts.Add(a);
            }
        }

        public async void goToAlertPage(object sender, EventArgs e)
        {
            Alert a = ((Alert)((ListView)sender).SelectedItem);
            Navigation.PushAsync(new AlertDetailPage(a));
        }
    }
}
