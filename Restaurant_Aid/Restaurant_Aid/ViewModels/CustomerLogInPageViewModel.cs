using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Restaurant_Aid.Model;
using Restaurant_Aid.Services;
using Restaurant_Aid.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace Restaurant_Aid.ViewModels
{
	public class CustomerLogInPageViewModel : BindableBase
	{
        public string username { get; set; }
        public string password { get; set; }
        INavigationService _navigationService;
        private ApiService apiService;

        public DelegateCommand logInSubmit { get; set; }

        public CustomerLogInPageViewModel(INavigationService navigationService)
        {
                _navigationService = navigationService;
                logInSubmit = new DelegateCommand(OnNavigateToCustomerAsync);
                apiService = new ApiService();

        }

        private async void OnNavigateToCustomerAsync()
        {
            Debug.WriteLine("Logging In!");
            try
            {
                Profile p = await apiService.GetProfile(username);
                if (p.passhash != password)
                {
                    await Application.Current.MainPage.DisplayAlert("ERROR", "Incorrect Password!", "Ok");
                    //DisplayAlert("ERROR", "Incorrect Password!", "Ok");
                }
                else
                {
                    App.pid = p.id;
                    App.ProfileCache = p;
                    await _navigationService.NavigateAsync(nameof(CustomerPage));
                }
            }
            catch
            {
                Console.WriteLine("Login Error");
                await _navigationService.NavigateAsync(nameof(CustomerPage));
            }
        }
    }
}
