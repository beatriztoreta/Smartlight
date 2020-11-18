using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SmartLight.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SmartLight.ViewModels
{
    public class MonitorViewModel : BaseViewModel
    {
        public MonitorViewModel()
        {
            Sec = new ObservableCollection<Sector_status>();
            Sen = new ObservableCollection<Sensor_status>();
            Lista = new List<Sector_status>();
            Lista_aux = new ObservableCollection<Sensor_status_aux>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            ListagemCommand = new Command(async () => await ExecuteListagemCommand());
        }

        public ObservableCollection<Sector_status> Sec { get; set; }
        
        public ObservableCollection<Sensor_status> Sen { get; set; }

        public List<Sector_status> Lista { get; set; }

        public Command LoadItemsCommand { get; }

        public Command ListagemCommand { get; }

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
                Lista.Clear();
                
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

                        Sen.Add(sen);
                    }

                    Sec.Add(sec);
                    Lista.Add(sec);
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

        public ObservableCollection<Sensor_status_aux> Lista_aux { get; set; }

        public async Task ExecuteListagemCommand()
        {
            IsBusy = true;

            try
            {
                Lista_aux.Clear();
                Sensor_status_aux aux = new Sensor_status_aux();

                Sector_status_aux item = await Data_Monitor_Store.GetItemAsync("proto");

                foreach (var sec in item.status_aux)
                {
                    aux = new Sensor_status_aux();
                    aux.sector = sec.sector;
                    aux.status_code_sector = sec.status_code;
                    if (sec.status_code == 0)
                    {
                        aux.status_code_sector_text = "Módulo central conectado e funcionando corretamente";
                    }
                    else if (sec.status_code == 1)
                    {
                        aux.status_code_sector_text = "Módulo central não está respondendo";
                    }
                    else if (sec.status_code == 2)
                    {
                        aux.status_code_sector_text = "Sensor de potência não conectado ao Módulo central";
                    }

                    foreach (var sen in sec.status)
                    {
                        if (sen == sec.status[0])
                        {
                            aux.sensor_name_1 = sen.sensor_name;
                            aux.sensor_tag_1 = sen.sensor_tag;
                            aux.status_code_1 = sen.status_code;

                            if (sen.status_code == 0)
                            {
                                aux.status_code_sensor_text_1 = $"{sen.sensor_name} conectado e funcionando corretamente";
                            }
                            else if (sec.status_code == 1)
                            {
                                aux.status_code_sensor_text_1 = $"{sen.sensor_name} não está respondendo";
                            }
                            else if (sec.status_code == 2)
                            {
                                aux.status_code_sensor_text_1 = $"Sensor não conectado ao {sen.sensor_name}";
                            }
                        }
                        else if (sen == sec.status[1])
                        {
                            aux.sensor_name_2 = sen.sensor_name;
                            aux.sensor_tag_2 = sen.sensor_tag;
                            aux.status_code_2 = sen.status_code;

                            if (sen.status_code == 0)
                            {
                                aux.status_code_sensor_text_2 = $"{sen.sensor_name} conectado e funcionando corretamente";
                            }
                            else if (sec.status_code == 1)
                            {
                                aux.status_code_sensor_text_2 = $"{sen.sensor_name} não está respondendo";
                            }
                            else if (sec.status_code == 2)
                            {
                                aux.status_code_sensor_text_2 = $"Sensor não conectado ao {sen.sensor_name}";
                            }
                        }

                    }

                    Lista_aux.Add(aux);
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
