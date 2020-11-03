using SmartLight.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartLight.Models;
using Plugin.Toast;
using Plugin.Toast.Abstractions;

namespace SmartLight.Views
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