using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppTCC.ViewModels;

namespace AppTCC.Views
{
    public partial class DashboardOperPage : ContentPage
    {
        public DashboardOperPage()
        {
            try
            {
                InitializeComponent();
                
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        private async void Monitors_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MonitorsPage());
        }

        private async void Parameters_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ParametersPage());
        }
    }
}