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
            //await Shell.Current.GoToAsync($"//{nameof(GraphicsPage)}");
            Application.Current.MainPage = new GraphicsPage();
        }

        private async void Projections_Tapped(object sender, System.EventArgs e)
        {
            //await Shell.Current.GoToAsync($"//{nameof(ProjectionsPage)}");
            Application.Current.MainPage = new ProjectionsPage();
        }

        private async void Monitors_Tapped(object sender, System.EventArgs e)
        {
            //await Shell.Current.GoToAsync($"//{nameof(MonitorsPage)}");
            Application.Current.MainPage = new MonitorsPage();
        }

        private async void Parameters_Tapped(object sender, System.EventArgs e)
        {
            //await Shell.Current.GoToAsync($"//{nameof(ParametersPage)}");
            Application.Current.MainPage = new ParametersPage();
        }
    }
}