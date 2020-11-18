using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrorLoginPage : ContentPage
    {
        public ErrorLoginPage()
        {
            InitializeComponent();
        }

        async void OnTryClicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new LoginPage());
        }
    }
}