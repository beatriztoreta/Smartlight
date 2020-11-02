using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using AppTCC.Models;
using AppTCC.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;
using SmartLight.Models;

namespace AppTCC.ViewModels
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

                Entity item = await Data_Entities_Store.GetItemAsync("proto");

                foreach (var sec in item.sectors)
                {
                    Sec.Add(new List_Sec
                    {
                        sector_tag = sec.sector_tag,
                        sector = sec.sector,
                    });
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
