using System;
using System.Diagnostics;
using Prism;
using Prism.Mvvm;
using Prism.Navigation;

namespace Restaurant_Aid.ViewModels
{
    public class TabContainerViewModel : BindableBase, IActiveAware, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        public TabContainerViewModel()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(TabContainerViewModel)}:  ctor");
            Title = "Tab Container";
            IsActiveChanged += OnIsActiveChanged;
        }

        public event EventHandler IsActiveChanged;

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                SetProperty(ref _isActive, value);
                IsActiveChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        void OnIsActiveChanged(object sender, EventArgs emptyEventArgs)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnIsActiveChanged)}:  {IsActive}");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedFrom)}");
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedTo)}");
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatingTo)}");
        }
    }
}
