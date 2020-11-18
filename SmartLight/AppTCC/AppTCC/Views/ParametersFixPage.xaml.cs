using SmartLight.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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