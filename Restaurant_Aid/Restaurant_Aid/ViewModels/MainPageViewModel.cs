using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Restaurant_Aid.Views;
using Restaurant_Aid.Controls;
using Xamarin.Forms;

namespace Restaurant_Aid.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        public DelegateCommand NavigateToCustomerCommand { get; set; }
        public DelegateCommand NavigateToRestaurantCommand { get; set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainPageViewModel(INavigationService navigationService)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(MainPageViewModel)}:  ctor");

            _navigationService = navigationService;
            NavigateToCustomerCommand = new DelegateCommand(OnNavigateToCustomer);
            NavigateToRestaurantCommand = new DelegateCommand(OnNavigateToRestaurant);
            Title = "Main Page";
        }

        private void OnNavigateToRestaurant()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToRestaurant)}");

            _navigationService.NavigateAsync(nameof(RestaurantPage));
        }

        private void OnNavigateToCustomer()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToCustomer)}");

            _navigationService.NavigateAsync(nameof(CustomerPage));
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedFrom)}");
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedTo)}");
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatingTo)}");
        }
    }
}
