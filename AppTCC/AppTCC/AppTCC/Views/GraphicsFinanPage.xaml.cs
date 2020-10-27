using AppTCC.Models;
using AppTCC.ViewModels;
using SkiaSharp;
using SQLitePCL;
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
    public partial class GraphicsFinanPage : ContentPage
    {
        List<Microcharts.ChartEntry> entries;

        Graphics_Data gra;

        GraphicsViewModel _viewModel;

        public GraphicsFinanPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new GraphicsViewModel();
            //Grafico.Chart = new Microcharts.DonutChart() { Entries = entries };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();

            await _viewModel.ExecuteLoadPizzaCommand();

            gra = _viewModel.Pizza;
            float max = (float)(gra.max / 3600.0);
            float min = (float)(gra.min / 3600.0);
            float ligado = (float)(max + min);
            DateTime agora = DateTime.Now;
            DateTime tempo = new DateTime(agora.Year, agora.Month, 1);

            float desligado = (float)(agora - tempo).TotalHours - ligado;

            entries = new List<Microcharts.ChartEntry>
            {
                new Microcharts.ChartEntry(max)
                {
                    Label = "Horas em intensidade máxima",
                    ValueLabel = max.ToString(),
                    Color = SKColor.Parse("#266489")
                },
                new Microcharts.ChartEntry(min)
                {
                    Label = "Horas em intensidade mínima",
                    ValueLabel = min.ToString(),
                    Color = SKColor.Parse("#68B9C0")
                },
                new Microcharts.ChartEntry(desligado)
                {
                    Label = "Total de horas desligado",
                    ValueLabel = desligado.ToString(),
                    Color = SKColor.Parse("#90D585")
                }
            };

            Grafico.Chart = new Microcharts.DonutChart() { Entries = entries };

            economia_label.Text = "teste";
        }
    }
}
