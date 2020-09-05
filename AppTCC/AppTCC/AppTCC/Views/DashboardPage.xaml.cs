using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppTCC.Models;
using AppTCC.ViewModels;

namespace AppTCC.Views
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
            BindingContext = new DashboardViewModel();
        }

        private async void Graphics_Tapped(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(GraphicsPage)}");
        }

        private async void Projections_Tapped(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(ProjectionsPage)}");
        }

        private async void Monitors_Tapped(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(MonitorsPage)}");
        }

        private async void Parameters_Tapped(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(ParametersPage)}");
        }
    }
}