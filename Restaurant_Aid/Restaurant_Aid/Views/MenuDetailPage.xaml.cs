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
	public partial class MenuDetailPage : ContentPage
	{
        RMenuItem TheMenuItem { get; set; }

		public MenuDetailPage ()
		{
			InitializeComponent ();
		}

        public MenuDetailPage(RMenuItem item)
        {
            InitializeComponent();
            TheMenuItem = item;
            BindingContext = TheMenuItem;
        }

        async void Edit_Clicked(object sender, System.EventArgs e)
        {
            var editPage = new MenuEdit(TheMenuItem);

            editPage.MenuItemSaved += (page, item) =>
            {
                BindingContext = null;
                TheMenuItem = item;
                BindingContext = TheMenuItem;
            };

            await Navigation.PushAsync(editPage);
        }
    }
}