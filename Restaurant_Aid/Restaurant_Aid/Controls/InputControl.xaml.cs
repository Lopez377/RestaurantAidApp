using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant_Aid.Controls
{
	public partial class InputControl : ContentPage
	{
        #region Constructor(s)
        public InputControl ()
		{
			InitializeComponent();
		}

        #endregion Constructor(s)

        #region Caption (Bindable string)
        public static readonly BindableProperty CaptionProperty = BindableProperty.Create("Caption", typeof(string), typeof(InputControl), string.Empty);
       
        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        #endregion Caption (Bindable string)
    }
}