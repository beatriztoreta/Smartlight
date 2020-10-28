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

        float gra;

        double f;

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
            await _viewModel.ExecuteLoadFinanCommand();

            gra = _viewModel.Pizza;
            f = _viewModel.fin;

            float economia = 100 - gra;

            entries = new List<Microcharts.ChartEntry>
            {
                new Microcharts.ChartEntry(economia)
                {
                    Label = "Economia estimada",
                    ValueLabel = economia.ToString(),
                    Color = SKColor.Parse("#F5790B")
                },
                new Microcharts.ChartEntry(gra)
                {
                    Label = "Consumo estimado",
                    ValueLabel = gra.ToString(),
                    Color = SKColor.Parse("#666666")
                }
            };

            Grafico.Chart = new Microcharts.DonutChart() { Entries = entries };

            economia_label.Text = f.ToString("C");
        }
    }
}
