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
using Prism.Navigation;

namespace Restaurant_Aid.ViewModels
{
	public class CustomerInformationPageViewModel : BindableBase, INavigationAware
	{
        public string cid { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string dob { get; set; }
        public CustomerInformationPageViewModel ()
		{
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Profile c = App.ProfileCache;
            cid = "Customer ID#: " + c.id.ToString();
            username = "Username: " + c.username;
            email = "E-Mail: " + c.email;
            dob = "DoB: " + c.dob;
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {        }
    }
}