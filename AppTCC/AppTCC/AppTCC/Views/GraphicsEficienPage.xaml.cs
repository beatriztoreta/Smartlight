using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using AppTCC.Models;
using AppTCC.ViewModels;

namespace AppTCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraphicsEficienPage : ContentPage
    {
        List<Microcharts.ChartEntry> entries = new List<Microcharts.ChartEntry>
        {
            new Microcharts.ChartEntry(200)
            {
                Label = "Janeiro",
                ValueLabel = "200",
                Color = SKColor.Parse("#266489")
            },
            new Microcharts.ChartEntry(250)
            {
                Label = "Fevereiro",
                ValueLabel = "250",
                Color = SKColor.Parse("#68B9C0")
            },
            new Microcharts.ChartEntry(100)
            {
                Label = "Março",
                ValueLabel = "100",
                Color = SKColor.Parse("#90D585")
            },
            new Microcharts.ChartEntry(150)
            {
                Label = "Abril",
                ValueLabel = "150",
                Color = SKColor.Parse("#e77e23")
            }
        };

        Graphics_Data gra;

        public GraphicsEficienPage()
        {
            InitializeComponent();
            this.BindingContext = new GraphicsViewModel();
            //gra = 
            Grafico.Chart = new Microcharts.BarChart() { Entries = entries };
        }

        async void OnFinanClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GraphicsFinanPage());
        }
    }
}