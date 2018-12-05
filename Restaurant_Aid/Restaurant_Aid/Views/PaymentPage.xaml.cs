using Restaurant_Aid.Model;
using Restaurant_Aid.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Restaurant_Aid.Views
{
    public partial class PaymentPage : ContentPage
    {
        private ApiService apiService;
        public PaymentPage()
        {
            InitializeComponent();
            apiService = new ApiService();
        }

        public async void submitOrder(object sender, EventArgs e)
        {
            List<string> mids = new List<string>();
            foreach(RMenuItem item in App.CMenuList)
            {
                mids.Add(item.id.ToString());
            }
            List<KeyValuePair<string, string>> formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("status","ORDERED"));
            formData.Add(new KeyValuePair<string, string>("detail", customerName.Text + " -- " + details.Text));
            formData.Add(new KeyValuePair<string, string>("rid", App.CMenuList[0].rid.ToString()));
            formData.Add(new KeyValuePair<string, string>("pid", App.pid.ToString()));
            formData.Add(new KeyValuePair<string, string>("mids", String.Join(",", mids)));
            if(await apiService.createOrder(formData))
            {
                App.CMenuList.Clear();
                Application.Current.MainPage.DisplayAlert("Success!", "Your order has been submitted!", "Ok!");
                Navigation.PopAsync();
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Oops!", "Something went wrong with your order!", "Ok.");
            }
        }
    }
}
