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
            //var editPage = new MenuEdit(TheMenuItem);

            //editPage.MenuItemSaved += (page, item) =>
            //{
            //    BindingContext = null;
            //    TheMenuItem = item;
            //    BindingContext = TheMenuItem;
            //};

            //await Navigation.PushAsync(editPage);
            //int i = 2;
            string CName = TheMenuItem.Name;
            string CDesc = TheMenuItem.Description;
            string cPrice = TheMenuItem.Price;


            //foreach (RMenuItem item in App.CMenuList)
            //{
            //    if (CName.Equals(item.Name))
            //    {
            //        CName = CName + i.ToString();

            //    }
            //    i++;
            //}

            App.CMenuList.Add(new RMenuItem { Id = Guid.NewGuid(), Name = CName, Description =CDesc, Price = cPrice });
            //App.CMenuList.Add(TheMenuItem); 
        }
    }
}