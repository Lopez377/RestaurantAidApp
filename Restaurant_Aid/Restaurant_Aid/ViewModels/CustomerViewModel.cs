using System;
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
        public DelegateCommand NavigateToCustomerMenuPageCommand { get; set; }
        public DelegateCommand NavigateToCustomerAccountPageCommand { get; set; }



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
            Title = "Customer Main Page";

            _navigationService = navigationService;
            NavigateToCustomerCartPageCommand = new DelegateCommand(OnNavigateToCustomerCart);
            NavigateToCustomerMenuPageCommand = new DelegateCommand(OnNavigateToCustomerMenu);
            NavigateToCustomerAccountPageCommand = new DelegateCommand(OnNavigateToCustomerAccount);

            IsActiveChanged += OnIsActiveChanged;
        }

        private void OnNavigateToCustomerCart()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToCustomerCart)}");

            _navigationService.NavigateAsync(nameof(CustomerCartPage));
        }

        private void OnNavigateToCustomerMenu()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToCustomerMenu)}");

            _navigationService.NavigateAsync(nameof(CustomerMenuPage));
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
