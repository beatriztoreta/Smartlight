using AppTCC.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTCC.Views
{
    public partial class DashboardPage2 : ContentPage
    {
        public DashboardPage2()
        {
            InitializeComponent();
            //this.BindingContext = new DashboardViewModel();
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