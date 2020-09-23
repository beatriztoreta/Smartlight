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
    public partial class GraphicsEficienPage : ContentPage
    {
        public GraphicsEficienPage()
        {
            InitializeComponent();
        }

        async void OnFinanClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GraphicsFinanPage());
        }
    }
}