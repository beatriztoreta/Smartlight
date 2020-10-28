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
using Android.Test.Suitebuilder.Annotation;

namespace AppTCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraphicsEficienPage : ContentPage
    {
        List<Microcharts.ChartEntry> entries; 

        Graphics_Data gra;

        GraphicsViewModel _viewModel;

        public GraphicsEficienPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new GraphicsViewModel();
            //Grafico.Chart = new Microcharts.BarChart() { Entries = entries };
        }

        async void OnFinanClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GraphicsFinanPage());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();

            //_viewModel.BarrasCommand.Execute("ExecuteLoadBarrasCommand");

            await _viewModel.ExecuteLoadBarrasCommand();

            gra = _viewModel.Barras;
            float max = (float)(gra.max/3600.0);
            float min = (float)(gra.min/3600.0);
            float ligado = (float)(max + min);
            DateTime agora = DateTime.Now;
            DateTime tempo = new DateTime(agora.Year, agora.Month, agora.Day);

            tempo = tempo.AddDays((int)agora.DayOfWeek*(-1));

            float desligado = (float)(agora.Subtract(tempo).TotalHours - ligado);
                        
            entries = new List<Microcharts.ChartEntry>
            {
                new Microcharts.ChartEntry(max)
                {
                    Label = "Horas em intensidade máxima",
                    ValueLabel = max.ToString(),
                    Color = SKColor.Parse("#F5790B")
                },
                new Microcharts.ChartEntry(min)
                {
                    Label = "Horas em intensidade mínima",
                    ValueLabel = min.ToString(),
                    Color = SKColor.Parse("#FEFA59")
                },
                new Microcharts.ChartEntry(desligado)
                {
                    Label = "Total de horas desligado",
                    ValueLabel = desligado.ToString(),
                    Color = SKColor.Parse("#666666")
                }
            };

            label.Text = "O Smart Light ficou ligado por " + ligado.ToString() + " horas";
            
            Grafico.Chart = new Microcharts.BarChart() { Entries = entries };
        }
    }
}