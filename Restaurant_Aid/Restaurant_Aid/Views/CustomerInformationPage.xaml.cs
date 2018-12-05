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
            c = App.ProfileCache;
            cidLabel.Text = "Customer ID#: " + c.id.ToString();
            usernameLabel.Text = "Username: " + c.username;
            emailLabel.Text = "E-Mail: " + c.email;
            dobLabel.Text = "DoB: " + c.dob;
        }
    }
}