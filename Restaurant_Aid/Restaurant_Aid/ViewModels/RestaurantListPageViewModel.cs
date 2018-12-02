using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Restaurant_Aid.Model;
using Restaurant_Aid.Services;
using Restaurant_Aid.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace Restaurant_Aid.ViewModels
{
	public class RestaurantListPageViewModel : BindableBase, INavigationAware, INotifyPropertyChanged
	{
        ApiService apiService;
        public ObservableCollection<Restaurant> restaurants { get; set; }
        public bool waiting { get; set; }
        INavigationService _navigationService;

        public RestaurantListPageViewModel(INavigationService navigationService)
        {
            waiting = true;
            apiService = new ApiService();
            restaurants = new ObservableCollection<Restaurant>();
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters) { }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            if(restaurants.Count() > 0)
            {
                return;
            }
            Debug.WriteLine("####Getting Restaurant List");
            foreach (Restaurant r in await apiService.GetRestaurants())
            {
                restaurants.Add(r);
            }
            waiting = false;
            this.RaisePropertyChanged("waiting");
        }

        public void OnNavigatingTo(INavigationParameters parameters) { }

    }
}
