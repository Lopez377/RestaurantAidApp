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
    public class RestaurantLogInViewModel : BindableBase
    {
        public string username { get; set; }
        public string password { get; set; }
        INavigationService _navigationService;
        private ApiService apiService;

        public DelegateCommand logInSubmit { get; set; }

        public RestaurantLogInViewModel(INavigationService navigationService)
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
                Restaurant r = await apiService.GetSingleRestaurantByUsername(username);
                if (r.passhash != password)
                {
                    await Application.Current.MainPage.DisplayAlert("ERROR", "Incorrect Password!", "Ok");
                    //DisplayAlert("ERROR", "Incorrect Password!", "Ok");
                }
                else
                {
                    App.rid = r.id;
                    await _navigationService.NavigateAsync(nameof(RestaurantPage));
                }
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("ERROR", "Incorrect Password!", "Ok");
            }
        }
    }
}
