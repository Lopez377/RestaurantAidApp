using Restaurant_Aid.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant_Aid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerItemDetail : ContentPage
    {
        RMenuItem TheMenuItem { get; set; }
        //RMenuItem item2;

        public CustomerItemDetail()
        {
            InitializeComponent();
        }

        public CustomerItemDetail(RMenuItem item)
        {
            InitializeComponent();
            TheMenuItem = item;
            BindingContext = TheMenuItem;
        }

        async void Cart_Clicked(object sender, System.EventArgs e)
        {

            App.CMenuList.Add(TheMenuItem);
            //App.CMenuList.Add(TheMenuItem); 
        }
    }
}