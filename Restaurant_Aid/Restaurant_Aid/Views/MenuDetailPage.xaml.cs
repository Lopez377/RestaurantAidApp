using Restaurant_Aid.Model;
using Restaurant_Aid.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant_Aid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuDetailPage : ContentPage
	{
        private string mid;
        private RMenuItem menuItem;
        private ApiService apiService;

		public MenuDetailPage (string mid)
		{
			InitializeComponent ();
            this.mid = mid;
            apiService = new ApiService();
		}

        protected override async void OnAppearing()
        {
            menuItem = await apiService.GetMenuItem(mid);
            nameLabel.Text = "Item Name: " + menuItem.name;
            priceLabel.Text = "Price: " + menuItem.price;
            descriptionLabel.Text = "Description: " + menuItem.description;
        }

        async void Edit_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MenuEdit(menuItem));
        }

        public async void deleteMenuItem(object sender, EventArgs e)
        {
            if (await apiService.deleteMenuItem(mid))
            {
                await DisplayAlert("SUCCESS!", "Menu Item deleted!", "Ok!");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("ERROR!", "Menu Item delete failed!", "Ok");
            }
        }
    }
}