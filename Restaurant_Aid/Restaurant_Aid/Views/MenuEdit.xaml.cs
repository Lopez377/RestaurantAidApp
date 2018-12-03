using Restaurant_Aid.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Restaurant_Aid.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant_Aid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuEdit : ContentPage
    {
        public event EventHandler<RMenuItem> MenuItemSaved;

        RMenuItem TheMenuItem { get; set; }
        bool IsNew { get; set; }

        public MenuEdit()
        {
            InitializeComponent();

            TheMenuItem = new RMenuItem();
            IsNew = true;

            InitializePage();
        }

        public MenuEdit(RMenuItem item)
        {
            InitializeComponent();

            TheMenuItem = item;
            IsNew = false;

            InitializePage();
        }

        void InitializePage()
        {
            Title = TheMenuItem.name ?? "New Menu Item";

            itemNameCell.Text = TheMenuItem.name;
            descriptionCell.Text = TheMenuItem.description;
            priceCell.Text = TheMenuItem.price;

            saveButton.Clicked += async (sender, args) =>
            {
                SaveMenuItem();
                await CloseWindow();
            };

            cancelButton.Clicked += async (sender, args) =>
            {
                await CloseWindow();
            };
        }

        async Task CloseWindow()
        {
            if (IsNew)
                await Navigation.PopModalAsync(true);
            else
                await Navigation.PopAsync(true);
        }

        void SaveMenuItem()
        {
            TheMenuItem.name = itemNameCell.Text;
            TheMenuItem.description = descriptionCell.Text;
            TheMenuItem.price = priceCell.Text;

            if (IsNew)
            {
                TheMenuItem.id = 0;
                //CHANGED
                App.RMenuList.Add(TheMenuItem);
            }
            else
            {
                //CHANGED
                var savedItem = App.RMenuList.Find(r => r.id == TheMenuItem.id);
                savedItem = TheMenuItem;

                MenuItemSaved?.Invoke(this, savedItem);
            }
        }
    }
}