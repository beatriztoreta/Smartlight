﻿using AppTCC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppTCC.Models;
using Plugin.Toast;
using Plugin.Toast.Abstractions;

namespace AppTCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParametersFixPage : ContentPage
    {
        public ParametersFixPage(int sector_tag)
        {
            InitializeComponent();
            this.BindingContext = new ParamFixViewModel(sector_tag);
        }

    }
}