using System;
using System.IO;
using Xamarin.Forms;
using SmartLight.ViewModels;
using SmartLight.Services;
using Xamarin.Forms.Internals;
using System.Diagnostics;
using System.Collections.ObjectModel;
using SmartLight.Models;
using SmartLight.Views;

namespace SmartLight
{
    public partial class App : Application
    {
        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            Xamarin.Forms.Internals.Log.Listeners.Add(new DelegateLogListener((arg1, arg2) => Debug.WriteLine(arg2)));

            DependencyService.Register<ApiPeopleDataStore>();
            DependencyService.Register<ApiEntitiesDataStore>();
            DependencyService.Register<ApiGraphicsDataStore>();
            DependencyService.Register<ApiGraphicsEficienDataStore>();
            DependencyService.Register<ApiGraphicsFinanDataStore>();
            DependencyService.Register<ApiParamDataStore>();
            DependencyService.Register<ApiMonitorDataStore>();
            //MainPage = new AppShell();
            MainPage = new LoginPage();
        }
        
        //MonitorViewModel _viewModel;

        //ObservableCollection<Sensor_status_aux> lista;

        protected override void OnStart()
        {
            
        }

        protected override async void OnSleep()
        {
            /*await _viewModel.ExecuteLoadItemsCommand();
            lista = _viewModel.Lista_aux;

            string msg = "";

            foreach (var i in lista)
            {
                msg = "";
                if (i.status_code_sector == 1)
                {
                    msg += i.sector + ": " + i.status_code_sector_text;
                    
                }
                else if (i.status_code_sector == 2)
                {
                    msg += i.sector + ": " + i.status_code_sector_text;
                    
                }
                else if (i.status_code_1 == 1)
                {
                    msg += i.sector + ": " + i.status_code_sensor_text_1;
                    
                }
                else if (i.status_code_1 == 2)
                {
                    msg += i.sector + ": " + i.status_code_sensor_text_1;
                    
                }
                else if (i.status_code_2 == 1)
                {
                    msg += i.sector + ": " + i.status_code_sensor_text_2;
                    
                }
                else if (i.status_code_2 == 2)
                {
                    msg += i.sector + ": " + i.status_code_sensor_text_2;
                   
                }
            }*/
        }

        protected override void OnResume()
        {
        }
    }
}
