﻿using Xamarin.Forms;
using Restaurant_Aid.ViewModels;
using System;
using System.Collections.Generic;
using Restaurant_Aid.Model;
using Restaurant_Aid;
using Restaurant_Aid.Services;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace Restaurant_Aid.Views
{
    public partial class CustomerMenuPage : ContentPage
    {
        public int rid;
        private ApiService apiService;
        public ObservableCollection<RMenuItem> menuListSource;
        public CustomerMenuPage(int _rid)
        {
            InitializeComponent();
            rid = _rid;
            menuList.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    var custDetailPage = new CustomerItemDetail(e.SelectedItem as RMenuItem);

                    await Navigation.PushAsync(custDetailPage);

                    menuList.SelectedItem = null;
                }
            };
            apiService = new ApiService();
            menuListSource = new ObservableCollection<RMenuItem>();
            menuList.ItemsSource = menuListSource;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            foreach(RMenuItem menuItem in await apiService.GetMenu(rid))
            {
                menuListSource.Add(menuItem);
            }
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
