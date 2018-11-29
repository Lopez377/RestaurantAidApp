using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Restaurant_Aid.Controls;
using Restaurant_Aid.Views;
using Restaurant_Aid.Model;

namespace Restaurant_Aid.ViewModels
{

    public class RestaurantMenuPageViewModel : ContentPage /*BindableBase, */
	{
        //public static List<RMenuItem> RMenuList { get; set; }
        public RestaurantMenuPageViewModel()
        {
           

        //    menuList.ItemSelected += async (sender, e) =>
        //    {
        //        if (e.SelectedItem != null)
        //        {
        //            var detailPage = new MenuDetailPage(e.SelectedItem as RMenuItem);

        //            await Navigation.PushAsync(detailPage);

        //            RMenuList.SelectedItem = null;
        //        }
        //    };
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    RestaurantViewModel.RMenuList. = null;
        //    menuList.ItemsSource = RestaurantViewModel.RMenuList;
        //}

        //RMenuList.ItemSelected += async(sender, eventArgs) =>
        //{
        //    if (eventArgs.SelectedItem != null)
        //    {
        //        var detailPage = new MenuDetailPage(eventArgs.SelectedItem as RMenuItem);

        //        await Navigation.PushAsync(detailPage);

        //        RMenuList.SelectedItem = null;
        //    }
        //};
        //async void Add_Clicked(object sender, System.EventArgs e)
        //{
        //    var editPage = new MenuEdit();

        //    var editNavPage = new NavigationPage(editPage)
        //    {
        //        BarBackgroundColor = Color.FromHex("#01487E"),
        //        BarTextColor = Color.White
        //    };

        //    await Navigation.PushModalAsync(editNavPage);
        //}


    }

}

