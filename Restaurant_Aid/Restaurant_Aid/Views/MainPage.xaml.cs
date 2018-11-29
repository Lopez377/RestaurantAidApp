using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Restaurant_Aid.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(MainPage)}:  ctor");
            InitializeComponent();
        }
    }
}