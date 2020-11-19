using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmartLight.Views
{
    public partial class DashboardOperPage : ContentPage
    {
        public DashboardOperPage()
        {
            try
            {
                InitializeComponent();
                
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        private async void Monitors_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MonitorsPage());
        }

        private async void Parameters_Tapped(object sender, System.EventArgs e)
        {
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