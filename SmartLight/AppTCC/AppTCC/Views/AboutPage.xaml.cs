using SmartLight.ViewModels;
using Xamarin.Forms;

namespace SmartLight.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            this.BindingContext = new AboutViewModel();
        }
    }
}