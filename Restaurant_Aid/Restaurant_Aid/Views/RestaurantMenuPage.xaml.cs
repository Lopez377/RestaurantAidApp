using Xamarin.Forms;
using Restaurant_Aid.ViewModels;
using System;
using System.Collections.Generic;
using Restaurant_Aid.Model;
using Restaurant_Aid.Services;
using System.Collections.ObjectModel;

namespace Restaurant_Aid.Views
{
    public partial class RestaurantMenuPage : ContentPage
    {
        private ApiService apiService;
        ObservableCollection<RMenuItem> menuItems;
        public RestaurantMenuPage()
        {
            InitializeComponent();
            apiService = new ApiService();
            menuItems = new ObservableCollection<RMenuItem>();
            menuList.ItemsSource = menuItems;
        }
        protected override async void OnAppearing()
        {
            menuItems.Clear();
            foreach(RMenuItem menuItem in await apiService.GetMenu(App.rid))
            {
                menuItems.Add(menuItem);
            }
        }

        async void Add_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddMenuItem());
        }

        async void goToDetailPage(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MenuDetailPage(((RMenuItem)((ListView)sender).SelectedItem).id.ToString()));
        }
    }
}
