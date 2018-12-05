using Restaurant_Aid.Model;
using Restaurant_Aid.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Restaurant_Aid.Views
{
    public partial class AlertDetailPage : ContentPage
    {
        private Alert alert;
        private ApiService apiService;

        public AlertDetailPage(Alert a)
        {
            InitializeComponent();
            alert = a;
            apiService = new ApiService();
            idLabel.Text = "Alert ID#: " + alert.id;
            statusLabel.Text = "Status: " + alert.status;
            detailLabel.Text = "Details: " + alert.detail;
        }

        public async void updateStatus(object sender, EventArgs e)
        {
            string status = (string)((Button)sender).CommandParameter;
            List<KeyValuePair<string, string>> formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("status", status));
            if (await apiService.editAlertStatus(alert.id.ToString(), formData))
            {
                await DisplayAlert("SUCCESS!", "Alert updated!", "Ok!");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("ERROR!", "Alert update failed!", "Ok");
            }
        }

        public async void deleteAlert(object sender, EventArgs e)
        {
            if (await apiService.deleteAlert(alert.id.ToString()))
            {
                await DisplayAlert("SUCCESS!", "Alert deleted!", "Ok!");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("ERROR!", "Alert delete failed!", "Ok");
            }
        }

    }
}
