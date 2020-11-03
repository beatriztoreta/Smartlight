using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using SmartLight.Models;
using SmartLight.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;
using SmartLight.Models;

namespace SmartLight.ViewModels
{
    public class MonitorViewModel : BaseViewModel
    {
        public MonitorViewModel()
        {
            Sec = new ObservableCollection<Sector_status>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public ObservableCollection<Sector_status> Sec { get; set; }
        public Command LoadItemsCommand { get; }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Sec.Clear();

                Sector_status_aux item = await Data_Monitor_Store.GetItemAsync("proto");

                foreach (var sec in item.status_aux)
                {
                    if (sec.status_code == 0)
                    {
                        sec.status_code_sector_text = "Módulo central conectado e funcionando corretamente";
                    }
                    else if (sec.status_code == 1)
                    {
                        sec.status_code_sector_text = "Módulo central não está respondendo";
                    }
                    else if (sec.status_code == 2)
                    {
                        sec.status_code_sector_text = "Sensor de potência não conectado ao Módulo central";
                    }

                    foreach (var sen in sec.status)
                    {
                        if (sen.status_code == 0)
                        {
                            sen.status_code_sensor_text = $"{sen.sensor_name} conectado e funcionando corretamente";
                        }
                        else if (sec.status_code == 1)
                        {
                            sen.status_code_sensor_text = $"{sen.sensor_name} não está respondendo";
                        }
                        else if (sec.status_code == 2)
                        {
                            sen.status_code_sensor_text = $"Sensor não conectado ao {sen.sensor_name}";
                        }
                    }

                    Sec.Add(sec);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
