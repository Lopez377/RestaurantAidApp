using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant_Aid.Model;
using Restaurant_Aid.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant_Aid.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomerInformationPage : ContentPage
	{
        private ApiService apiService;
        private Profile c;

        public CustomerInformationPage()
        {
            InitializeComponent();
            apiService = new ApiService();
        }

        protected override async void OnAppearing()
        {
            //c = await apiService.GetProfile();
            //Cid.Text = "Customer ID#: " + c.id.ToString();
            //Username.Text = "Username: " + c.username;
            //Email.Text = "E-Mail: " + c.email;
            //Dob.Text = "DoB: " + c.dob;
        }
    }
}