﻿using System;
using Prism;
using Prism.Ioc;
using Restaurant_Aid.ViewModels;
using Restaurant_Aid.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using Restaurant_Aid.Model;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Restaurant_Aid
{
    public partial class App
    {
        public static List<RMenuItem> RMenuList { get; set; }
        public static List<RMenuItem> CMenuList { get; set; }
        public static Profile ProfileCache { get; set; }
        public static int pid { get; set; }
        public static int rid { get; set; }

        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) {
            InitializeComponent();

            //RMenuList = new List<RMenuItem>();
            //RMenuList.Add(new RMenuItem { Id = Guid.NewGuid(), Name = "Pizza", Description = "Yummy Pizza", Price = "10.99" });
            //CMenuList = new List<RMenuItem>();
            //CMenuList.Add(new RMenuItem { Id = Guid.NewGuid(), Name = "Pizza", Description = "Yummy Pizza", Price = "10.99" });
        }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            RMenuList = new List<RMenuItem>();
            RMenuList.Add(new RMenuItem { id = 0, name = "Pizza", description = "Yummy Pizza", price = "10.99" });
            CMenuList = new List<RMenuItem>();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            //Register pages for navigation! Or else you'll never navigate.
            //containerRegistry.RegisterForNavigation<TabContainer, TabContainerViewModel>();

            containerRegistry.RegisterForNavigation<CustomerPage, CustomerViewModel>();
            containerRegistry.RegisterForNavigation<RestaurantPage, RestaurantViewModel>();
            containerRegistry.RegisterForNavigation<CustomerInformationPage, CustomerInformationPageViewModel>();
            containerRegistry.RegisterForNavigation<RestaurantAccountPage, RestaurantAccountPageViewModel>();
            containerRegistry.RegisterForNavigation<RestaurantPingPage, RestaurantPingPageViewModel>();
            containerRegistry.RegisterForNavigation<RestaurantMenuPage, RestaurantMenuPageViewModel>();
            containerRegistry.RegisterForNavigation<CustomerAccountPage, CustomerAccountPageViewModel>();
            containerRegistry.RegisterForNavigation<CustomerSearchPage, CustomerSearchPageViewModel>();
            containerRegistry.RegisterForNavigation<CustomerCartPage, CustomerCartPageViewModel>();
            containerRegistry.RegisterForNavigation<CustomerMenuPage, RestaurantViewModel>();
            containerRegistry.RegisterForNavigation<RestaurantListPage, RestaurantListPageViewModel>();
            containerRegistry.RegisterForNavigation<CustomerLogInPage, CustomerLogInPageViewModel>();
            containerRegistry.RegisterForNavigation<AccountCreationPage, AccountCreationPageViewModel>();
            containerRegistry.RegisterForNavigation<PaymentPage, PaymentPageViewModel>();
            containerRegistry.RegisterForNavigation<OrderInfoPage, OrderInfoPageViewModel>();
            containerRegistry.RegisterForNavigation<RestaurantLogIn, RestaurantLogInViewModel>();
            containerRegistry.RegisterForNavigation<RestaurantCreationPage, RestaurantCreationPageViewModel>();
            containerRegistry.RegisterForNavigation<RestaurantAccountEditPage, RestaurantAccountEditPageViewModel>();
            containerRegistry.RegisterForNavigation<AlertDetailPage, AlertDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<RestaurantOrderPage, RestaurantOrderPageViewModel>();
            containerRegistry.RegisterForNavigation<RestaurantOrderInfoPage, RestaurantOrderInfoPageViewModel>();
            containerRegistry.RegisterForNavigation<AddMenuItem, AddMenuItemViewModel>();
        }
    }
}
