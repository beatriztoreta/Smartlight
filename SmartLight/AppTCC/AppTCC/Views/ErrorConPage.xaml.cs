using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrorConPage : ContentPage
    {
        public ErrorConPage()
        {
            InitializeComponent();
        }

        async void OnTryClicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new LoginPage());
        }
    }
}