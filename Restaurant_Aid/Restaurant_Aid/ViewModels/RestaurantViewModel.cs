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
using Restaurant_Aid.Model;


namespace Restaurant_Aid.ViewModels
{
    public class RestaurantViewModel : BindableBase, IActiveAware, INavigationAware
    {
        private string _title;

        INavigationService _navigationService;
        public DelegateCommand NavigateToRestaurantAccountPageCommand { get; set; }
        public DelegateCommand NavigateToRestaurantPingPageCommand { get; set; }
        public DelegateCommand NavigateToRestaurantMenuPageCommand { get; set; }

        public event EventHandler IsActiveChanged;

        //public static List<RMenuItem> RMenuList { get; set; }

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

        public RestaurantViewModel(INavigationService navigationService)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RestaurantViewModel)}:  ctor");
            Title = "Restaurant Main Page";

            _navigationService = navigationService;
            NavigateToRestaurantAccountPageCommand = new DelegateCommand(OnNavigateToRestaurantAccount);
            NavigateToRestaurantPingPageCommand = new DelegateCommand(OnNavigateToRestaurantPing);
            NavigateToRestaurantMenuPageCommand = new DelegateCommand(OnNavigateToRestaurantMenu);

            //RMenuList = new List<RMenuItem>();
            //RMenuList.Add(new RMenuItem { Id = Guid.NewGuid(), Name = "Pizza", Description = "Yummy Pizza", Price = "10.99" });

            IsActiveChanged += OnIsActiveChanged;
        }

        #region NavigationStuff
        private void OnNavigateToRestaurantMenu()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToRestaurantMenu)}");

            _navigationService.NavigateAsync(nameof(RestaurantMenuPage));
        }

        private void OnNavigateToRestaurantPing()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToRestaurantPing)}");

            _navigationService.NavigateAsync(nameof(RestaurantPingPage));
        }

        private void OnNavigateToRestaurantAccount()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigateToRestaurantAccount)}");

            _navigationService.NavigateAsync(nameof(RestaurantAccountPage));
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
        #endregion NavigationStuff

    }
}
