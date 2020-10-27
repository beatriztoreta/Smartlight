using AppTCC.Models;
using AppTCC.ViewModels;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParametersPage : ContentPage
    {
        List<Microcharts.ChartEntry> entries;

        ParamViewModel _viewModel;

        GraphicsViewModel _graficoView;

        Graphics_Data gra;

        public ParametersPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new ParamViewModel();
            _graficoView = new GraphicsViewModel();

        }

        private async void Section_Tapped(object sender, System.EventArgs e)
        {
            var label = (sender as Label);

            await Navigation.PushAsync(new ParametersFixPage(Convert.ToInt32(label.Text)));
        }

        protected override async void OnAppearing()
        {
            
            base.OnAppearing();
            _viewModel.OnAppearing();

            await _graficoView.ExecuteLoadBarrasCommand();
            gra = _graficoView.Barras;
            float max = (float)(gra.max / 3600.0);
            float min = (float)(gra.min / 3600.0);
            float ligado = (float)(max + min);
            DateTime agora = DateTime.Now;
            DateTime tempo = new DateTime(agora.Year, agora.Month, agora.Day);

            tempo = tempo.AddDays((int)agora.DayOfWeek * (-1));

            float desligado = (float)(agora.Subtract(tempo).TotalHours - ligado);

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

            label.Text = "O Smart Light ficou ligado por " + ligado.ToString() + " horas";

            Grafico.Chart = new Microcharts.BarChart() { Entries = entries };
        }
    }
}