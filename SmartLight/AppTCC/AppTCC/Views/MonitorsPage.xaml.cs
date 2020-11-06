using SmartLight.Models;
using SmartLight.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartLight.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonitorsPage : ContentPage
    {
        MonitorViewModel _viewModel;

        //List<Sector_status> lista;

        //ObservableCollection<Sector_status> lista_aux;

        public MonitorsPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new MonitorViewModel();

            //StackLayout stackLayout1 = new StackLayout();
            //StackLayout stackLayout2 = new StackLayout();

            //lista_aux = new ObservableCollection<Sector_status>();
            //lista = new List<Sector_status>();
            
            //listView = new ListView();
           
        }

        /*private void Listagem()
        {
            listView = new ListView();
            foreach (var sector in lista)
            {
                lista_aux.Add(sector.sector);
                lista_aux.Add(sector.status_code_sector_text);

                foreach (var sensor in sector.status)
                {
                    lista_aux.Add(sensor.sensor_name);
                    lista_aux.Add(sensor.status_code_sensor_text);
                }
            }

            listView.ItemsSource = lista_aux;
        }*/


        protected override async void OnAppearing()
        {
            this.BindingContext = _viewModel = new MonitorViewModel();
            base.OnAppearing();
            _viewModel.OnAppearing();

            //await _viewModel.ExecuteLoadItemsCommand();
            //lista = _viewModel.Lista;

            /*Listagem();
            lista_aux.Clear();

            var listView = new ListView();
            foreach (var sector in lista)
            {
                lista_aux.Add(sector);

            }

            listView.ItemsSource = lista_aux;


            stackLayout1 = new StackLayout();
            stackLayout2 = new StackLayout();

            await _viewModel.ExecuteLoadItemsCommand();
            lista = _viewModel.Lista;

            foreach (var sector in lista)
            {
                stackLayout1.Children.Add(new Label() { Text = sector.sector, FontSize = 30, TextColor = Color.Black });
                stackLayout1.Children.Add(new Label() { Text = sector.status_code_sector_text, FontSize = 20, TextColor = Color.Black });

                foreach (var sensor in sector.status)
                {
                    stackLayout2.Children.Add(new Label() { Text = sensor.sensor_name, FontSize = 20, TextColor = Color.Black });
                    stackLayout2.Children.Add(new Label() { Text = sensor.status_code_sensor_text, FontSize = 20, TextColor = Color.Black });

                    if (sensor.status_code == 1 || sensor.status_code == 2)
                    {
                        stackLayout1.BackgroundColor = Color.Red;
                        stackLayout2.BackgroundColor = Color.Red;
                    }
                    else
                    {
                        stackLayout1.BackgroundColor = Color.Green;
                        stackLayout2.BackgroundColor = Color.Green;
                    }
                }

                if (sector.status_code == 1 || sector.status_code == 2)
                {
                    stackLayout1.BackgroundColor = Color.Red;
                    stackLayout2.BackgroundColor = Color.Red;
                }
                else
                {
                    stackLayout1.BackgroundColor = Color.Green;
                    stackLayout2.BackgroundColor = Color.Green;
                }

            }*/

        }
    }
}