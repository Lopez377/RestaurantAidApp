using Restaurant_Aid.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Restaurant_Aid.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Restaurant_Aid.Services;

namespace Restaurant_Aid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuEdit : ContentPage
    {
        private RMenuItem menuItem;
        private ApiService apiService;

        public MenuEdit(RMenuItem menuItem)
        {
            InitializeComponent();
            this.menuItem = menuItem;
            apiService = new ApiService();
            nameEntry.Text = menuItem.name;
            priceEntry.Text = menuItem.price;
            descriptionEntry.Text = menuItem.description;
        }

        public async void submitChanges(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("name", nameEntry.Text));
            formData.Add(new KeyValuePair<string, string>("price", priceEntry.Text));
            formData.Add(new KeyValuePair<string, string>("description", descriptionEntry.Text));
            if (await apiService.editMenuItem(menuItem.id.ToString(), formData))
            {
                await DisplayAlert("SUCCESS!", "Your menu item has been edited!", "Ok!");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("ERROR!", "Your menu item failed to be edited!", "Ok");
            }
        }
    }
}