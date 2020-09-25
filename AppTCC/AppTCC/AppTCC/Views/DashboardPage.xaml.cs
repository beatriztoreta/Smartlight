﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppTCC.ViewModels;

namespace AppTCC.Views
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            try
            {
                InitializeComponent();
                BindingContext = new DashboardViewModel();
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        private async void Graphics_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new GraphicsEficienPage());
        }

        private async void Projections_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ProjectionsPage());
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