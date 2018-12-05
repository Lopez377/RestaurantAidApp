using Xamarin.Forms;
using Restaurant_Aid.ViewModels;
using System;
using System.Collections.Generic;
using Restaurant_Aid.Model;
using Prism.Navigation;

namespace Restaurant_Aid.Views
{
    public partial class CustomerCartPage : ContentPage
    {
        public CustomerCartPage()
        {
            InitializeComponent();
            cmenuList.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    var answer = await DisplayAlert("Edit", "Remove from cart?", "Yes", "No");
                    if (answer != false)
                    {
                        App.CMenuList.Remove(e.SelectedItem as RMenuItem);
                        cmenuList.ItemsSource = null;
                        cmenuList.ItemsSource = App.CMenuList;
                    }

                }
                ((ListView)sender).SelectedItem = null;
            };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            cmenuList.ItemsSource = null;
            //CHANGED
            cmenuList.ItemsSource = App.CMenuList;
        }

        public async void goToCheckout(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaymentPage());
        }

    }
}
