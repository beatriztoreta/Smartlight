using AppTCC.ViewModels;
using System;
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
        ParamViewModel _viewModel;

        public ParametersPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ParamViewModel();
        }

        private async void Section_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ParametersFixPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}