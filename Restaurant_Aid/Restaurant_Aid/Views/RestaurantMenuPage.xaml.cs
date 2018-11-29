using Xamarin.Forms;
using Restaurant_Aid.ViewModels;
using System;
using System.Collections.Generic;
using Restaurant_Aid.Model;

namespace Restaurant_Aid.Views
{
    public partial class RestaurantMenuPage : ContentPage
    {
        
        public RestaurantMenuPage()
        {
            InitializeComponent();
            menuList.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    var detailPage = new MenuDetailPage(e.SelectedItem as RMenuItem);

                    await Navigation.PushAsync(detailPage);

                    menuList.SelectedItem = null;
                }
            };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            menuList.ItemsSource = null;
            //CHANGED
            menuList.ItemsSource = App.RMenuList;
        }

        async void Add_Clicked(object sender, System.EventArgs e)
        {
            var editPage = new MenuEdit();

            var editNavPage = new NavigationPage(editPage)
            {
                BarBackgroundColor = Color.FromHex("#01487E"),
                BarTextColor = Color.White
            };

            await Navigation.PushModalAsync(editNavPage);
        }
    }
}
