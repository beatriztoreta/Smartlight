﻿using System;
using Xamarin.Forms;
using Xamarin.Essentials;

using SmartLight.ViewModels;

namespace SmartLight.Views
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            try
            {
                InitializeComponent();
                //BindingContext = new DashboardViewModel();
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        private async void Graphics_Tapped(object sender, System.EventArgs e)
        {
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
            await Navigation.PushAsync(new GraphicsEficienPage());
        }

        private async void Projections_Tapped(object sender, System.EventArgs e)
        {
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
            await Navigation.PushAsync(new GraphicsFinanPage());
        }

        private async void Monitors_Tapped(object sender, System.EventArgs e)
        {
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
            await Navigation.PushAsync(new MonitorsPage());
        }

        private async void Parameters_Tapped(object sender, System.EventArgs e)
        {
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
            await Navigation.PushAsync(new ParametersPage());
        }

        private async void About_Tapped(object sender, System.EventArgs e)
        {
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
            await Navigation.PushAsync(new AboutPage());
        }

        private async void Logout_Tapped(object sender, System.EventArgs e)
        {
            var duration = TimeSpan.FromSeconds(2);
            Vibration.Vibrate(duration);
            Application.Current.MainPage = new LoginPage();
        }
    }
}