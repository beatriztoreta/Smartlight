using AppTCC.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using AppTCC;
using Plugin.Toast;
using AppTCC.Services;
using AppTCC.Models;
using Plugin.Toast.Abstractions;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using System.Linq;
using System.ComponentModel;
using Android.Bluetooth.LE;
using MongoDB.Bson;

namespace AppTCC.ViewModels
{
    public class ParamViewModel : BaseViewModel
    {
        private int min;
        private int max;

        private int sector_tag;

        public int Sector_tag
        {
            get => sector_tag;
            set => SetProperty(ref sector_tag, value);
        }

        public Command ParamCommand { get; }

        public ParamViewModel()
        {
            source = new List<Obj_Sector>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ParamCommand = new Command(OnSend);

            this.PropertyChanged += (_, __) => ParamCommand.ChangeCanExecute();
        
        }

        private bool ValidateSave()
        {
            if (min >= 0 && min <= 100 && max >= 0 && max <= 100)
                return true;
            else
                return false;
        }

        public int Min
        {
            get => min;
            set => SetProperty(ref min, value);
        }

        public int Max
        {
            get => max;
            set => SetProperty(ref max, value);
        }

        private async void OnSend()
        {
            if (ValidateSave() == true)
            {
                Entity newItem = new Entity()
                {
                    _id = Guid.NewGuid().ToString(),
                    
                };

                await Data_Entities_Store.AddItemAsync(newItem);

                await Shell.Current.GoToAsync("..");

                CrossToastPopUp.Current.ShowToastMessage("Paramentros enviados com sucesso!", ToastLength.Long);
            }
            else
                CrossToastPopUp.Current.ShowToastMessage("Preencha os campos!", ToastLength.Long);

        }

        private ObservableCollection<Entity> Items { get; }
        public ObservableCollection<Obj_Sector> Sec { get; private set; }
        public Command LoadItemsCommand { get; }

        async Task CreateSectorCollection()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                Sec.Clear();
                var items = await Data_Entities_Store.GetItemsAsync();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
                
                foreach (var sec in Items)
                {
                    int i = sec.sectors.Count();
                    while (i >= 0)
                    {
                        Sec.Add(sec.sectors[i]);
                    }
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

        public void OnAppearing()
        {
            IsBusy = true;
        }

        readonly IList<Obj_Sector> source;

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                Sec.Clear();
                var items = await Data_Entities_Store.GetItemsAsync();
                List<bool> st;
                List<Info_sensor> sens;
                List<Info> pow;
                foreach (var item in items)
                {
                    Items.Add(item);
                    foreach (var sec in item.sectors)
                    {
                        st = sec.status;
                        sens = sec.sensors;
                        pow = sec.power;
                        source.Add(new Obj_Sector
                        {
                            sector_tag = sec.sector_tag,
                            sector = sec.sector,
                            status = st,
                            max_intensity = sec.max_intensity,
                            min_intensity = sec.min_intensity,
                            sensors = sens,
                            power = pow
                        });
                    }
                }

                Sec = new ObservableCollection<Obj_Sector>(source);
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
