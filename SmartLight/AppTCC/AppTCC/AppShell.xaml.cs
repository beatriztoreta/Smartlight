﻿using System;
using SmartLight.Views;
using Xamarin.Forms;

namespace SmartLight
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
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void OnDashboardClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DashboardPage());
        }
        private async void OnAboutClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }
    }
}
