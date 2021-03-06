﻿using System;
using System.Diagnostics;
using Prism;
using Prism.Mvvm;
using Prism.Navigation;
using Restaurant_Aid.Views;
using Prism.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Restaurant_Aid.ViewModels
{
    public class CustomerViewModel : BindableBase, IActiveAware, INavigationAware
    {
        private string _title;

        INavigationService _navigationService;
        public DelegateCommand NavigateToCustomerCartPageCommand { get; set; }
        public DelegateCommand NavigateToCustomerAccountPageCommand { get; set; }
        public DelegateCommand NavigateToRestaurantListPage { get; set; }
        public DelegateCommand NavigateToCustomerInfoPageCommand { get; set; }



        public event EventHandler IsActiveChanged;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                SetProperty(ref _isActive, value);
                IsActiveChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public CustomerViewModel(INavigationService navigationService)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(CustomerViewModel)}:  ctor");
            Title = "Welcome to Restaurant Aid!";

            _navigationService = navigationService;
            NavigateToCustomerCartPageCommand = new DelegateCommand(OnNavigateToCustomerCart);
            NavigateToCustomerAccountPageCommand = new DelegateCommand(OnNavigateToCustomerAccount);
            NavigateToRestaurantListPage = new DelegateCommand(OnNavigateToRestaurantList);
            NavigateToCustomerInfoPageCommand = new DelegateCommand(OnNavigateToInfo);

            IsActiveChanged += OnIsActiveChanged;
        }

        private void OnNavigateToInfo()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToInfo)}");

            _navigationService.NavigateAsync(nameof(CustomerInformationPage));
        }


        private void OnNavigateToRestaurantList()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToRestaurantList)}");

            _navigationService.NavigateAsync(nameof(RestaurantListPage));
        }

        private void OnNavigateToCustomerCart()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToCustomerCart)}");

            _navigationService.NavigateAsync(nameof(CustomerCartPage));
        }

        private void OnNavigateToCustomerAccount()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToCustomerAccount)}");
            _navigationService.NavigateAsync(nameof(CustomerAccountPage));
        }



        private void OnIsActiveChanged(object sender, EventArgs e)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnIsActiveChanged)}: {IsActive}");
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
