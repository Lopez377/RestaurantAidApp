using Restaurant_Aid.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Restaurant_Aid.Views
{
    public partial class AddMenuItem : ContentPage
    {
        private ApiService apiService;
        public AddMenuItem()
        {
            InitializeComponent();
            apiService = new ApiService();
        }

        public async void submitItem(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("price", priceEntry.Text));
            formData.Add(new KeyValuePair<string, string>("name", nameEntry.Text));
            formData.Add(new KeyValuePair<string, string>("description", descriptionEntry.Text));
            formData.Add(new KeyValuePair<string, string>("rid", App.rid.ToString()));
            if (await apiService.createMenuItem(formData))
            {
                await DisplayAlert("SUCCESS!", "Your item has been created!", "Ok!");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("ERROR!", "Your item failed to be created!", "Ok");
            }
        }
    }
}
