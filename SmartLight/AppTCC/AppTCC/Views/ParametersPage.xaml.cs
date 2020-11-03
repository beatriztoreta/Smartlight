using SmartLight.Models;
using SmartLight.ViewModels;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartLight.Views
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

            try
            {
                Convert.ToInt32(label.Text);
                await Navigation.PushAsync(new ParametersFixPage(Convert.ToInt32(label.Text)));
            }
            catch
            {

                string text = label.Text.Remove(0, 6);
                await Navigation.PushAsync(new ParametersFixPage(Convert.ToInt32(text)));
            }
        }

        protected override async void OnAppearing()
        {
            this.BindingContext = _viewModel = new ParamViewModel();
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
                    TextColor = SKColor.Parse("#FFFFFF"),
                    Color = SKColor.Parse("#F5790B")
                },
                new Microcharts.ChartEntry(min)
                {
                    Label = "Horas em intensidade mínima",
                    ValueLabel = min.ToString(),
                    TextColor = SKColor.Parse("#FFFFFF"),
                    Color = SKColor.Parse("#FEFA59")
                },
                new Microcharts.ChartEntry(desligado)
                {
                    Label = "Total de horas desligado",
                    ValueLabel = desligado.ToString(),
                    TextColor = SKColor.Parse("#FFFFFF"),
                    Color = SKColor.Parse("#666666")
                }
            };

            label.Text = "O Smart Light ficou ligado por " + ligado.ToString() + " horas";

            Grafico.Chart = new Microcharts.BarChart() { Entries = entries };
            Grafico.Chart.BackgroundColor = SKColor.Parse("#000000");
        }
    }
}