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

        //ObservableCollection<Sensor_status_aux> lista;

        public MonitorsPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new MonitorViewModel();
        }

        protected override async void OnAppearing()
        {
            this.BindingContext = _viewModel = new MonitorViewModel();
            base.OnAppearing();
            _viewModel.OnAppearing();

            /*await _viewModel.ExecuteLoadItemsCommand();
            lista = _viewModel.Lista_aux;

            string msg = "";

            foreach (var i in lista)
            {
                msg = "";
                if (i.status_code_sector == 1)
                {
                    msg += i.sector + ": " + i.status_code_sector_text;
                    //enviar a vriável msg na notificação
                }
                else if (i.status_code_sector == 2)
                {
                    msg += i.sector + ": " + i.status_code_sector_text;
                    //enviar a vriável msg na notificação
                }
                else if (i.status_code_1 == 1)
                {
                    msg += i.sector + ": " + i.status_code_sensor_text_1;
                    //enviar a vriável msg na notificação
                }
                else if (i.status_code_1 == 2)
                {
                    msg += i.sector + ": " + i.status_code_sensor_text_1;
                    //enviar a vriável msg na notificação
                }
                else if (i.status_code_2 == 1)
                {
                    msg += i.sector + ": " + i.status_code_sensor_text_2;
                    //enviar a vriável msg na notificação
                }
                else if (i.status_code_2 == 2)
                {
                    msg += i.sector + ": " + i.status_code_sensor_text_2;
                    //enviar a vriável msg na notificação
                }
            }*/

        }
    }
}