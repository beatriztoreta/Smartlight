﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParametersPage : ContentPage
    {
        public ParametersPage()
        {
            InitializeComponent();
        }

        private async void Section_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ParametersFixPage());
        }
    }
}