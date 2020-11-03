using SmartLight.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonitorsPage : ContentPage
    {
        MonitorViewModel _viewModel;

        public MonitorsPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new MonitorViewModel();
        }

        protected override async void OnAppearing()
        {
            this.BindingContext = _viewModel = new MonitorViewModel();
            base.OnAppearing();
            _viewModel.OnAppearing();            
        }
    }
}