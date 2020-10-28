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

        public IList<List_Sec> sectors_lista { get; private set; }


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

            BindingContext = this;

            sectors_lista = new List<List_Sec>();

            await _viewModel.ExecuteLoadItemsCommand();

            sectors_lista = _viewModel.source;

            var customCell = new DataTemplate(typeof(CustomCell));
            customCell.SetBinding(CustomCell.Sector_Tag_Property, "Sector_Tag");
            customCell.SetBinding(CustomCell.Sector_Property, "Sector");
     
            var listView = new ListView
            {
                ItemsSource = sectors_lista,
                ItemTemplate = customCell
            };


        }

        private async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            var label = (sender as Label);

            await Navigation.PushAsync(new ParametersFixPage(Convert.ToInt32(label.Text)));
        }
    }






    public class CustomCell : ViewCell
    {
        Label sector_tag_Label, sector_Label;

        public static readonly BindableProperty Sector_Tag_Property = BindableProperty.Create("Sector_Tag", typeof(int), typeof(CustomCell), 0);
        public static readonly BindableProperty Sector_Property = BindableProperty.Create("Sector", typeof(string), typeof(CustomCell), "Sector");

        public int Sector_Tag
        {
            get { return (int)GetValue(Sector_Tag_Property); }
            set { SetValue(Sector_Tag_Property, value); }
        }

        public string Sector
        {
            get { return (string)GetValue(Sector_Property); }
            set { SetValue(Sector_Property, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                sector_tag_Label.Text = Sector_Tag.ToString();
                sector_Label.Text = Sector;
            }
        }
    }
}