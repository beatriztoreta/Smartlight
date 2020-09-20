using System;
using System.Collections.Generic;
using AppTCC.ViewModels;
using AppTCC.Views;
using Xamarin.Forms;

namespace AppTCC
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
            //Application.Current.MainPage = new DashboardPage();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }

        private async void OnDashboardClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new DashboardPage();
        }
        private async void OnAboutClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AboutPage();
        }
    }
}
