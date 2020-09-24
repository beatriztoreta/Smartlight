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