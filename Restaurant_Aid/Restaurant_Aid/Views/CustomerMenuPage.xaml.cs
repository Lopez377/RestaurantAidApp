using Xamarin.Forms;
using Restaurant_Aid.ViewModels;
using System;
using System.Collections.Generic;
using Restaurant_Aid.Model;
using Restaurant_Aid;

namespace Restaurant_Aid.Views
{
    public partial class CustomerMenuPage : ContentPage
    {
        
        public CustomerMenuPage()
        {
            InitializeComponent();
            menuList.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    var custDetailPage = new CustomerItemDetail(e.SelectedItem as RMenuItem);

                    await Navigation.PushAsync(custDetailPage);

                    menuList.SelectedItem = null;
                }
            };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            menuList.ItemsSource = null;
            // CHANGED
            menuList.ItemsSource = App.RMenuList;
        }

       /* async void Add_Clicked(object sender, System.EventArgs e)
        {
            var editPage = new MenuEdit();

            var editNavPage = new NavigationPage(editPage)
            {
                BarBackgroundColor = Color.FromHex("#01487E"),
                BarTextColor = Color.White
            };

            await Navigation.PushModalAsync(editNavPage);
        }*/
    }
}
