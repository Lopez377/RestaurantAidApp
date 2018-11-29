using Xamarin.Forms;
using Restaurant_Aid.ViewModels;
using System;
using System.Collections.Generic;
using Restaurant_Aid.Model;

namespace Restaurant_Aid.Views
{
    public partial class CustomerCartPage : ContentPage
    {
        public CustomerCartPage()
        {
            InitializeComponent();
            //menuList.ItemSelected += async (sender, e) =>
            //{
            //    if (e.SelectedItem != null)
            //    {
            //        var detailPage = new MenuDetailPage(e.SelectedItem as RMenuItem);

            //        await Navigation.PushAsync(detailPage);

            //        menuList.SelectedItem = null;
            //    }
            //};
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            cmenuList.ItemsSource = null;
            //CHANGED
            cmenuList.ItemsSource = App.CMenuList;
        }
    }
}
