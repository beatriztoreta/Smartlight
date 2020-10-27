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
using Newtonsoft.Json;

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
            source = new List<List_Sec>();
            Sec = new ObservableCollection<List_Sec>();
            LoadItemsCommand = new Command(async () => ExecuteLoadItemsCommand());

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

        public ObservableCollection<List_Sec> Sec { get; set; }
        public Command LoadItemsCommand { get; }
        
        public void OnAppearing()
        {
            IsBusy = true;
        }

        public List<List_Sec> source;

        async void ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            
            try
            {
                Sec.Clear();

                Entity item = await Data_Entities_Store.GetItemAsync("proto");
                                
                foreach (var sec in item.sectors)
                {
                    source.Add(new List_Sec
                    {
                        sector_tag = sec.sector_tag,
                        sector = sec.sector,
                    });
                }
                
                Sec = new ObservableCollection<List_Sec>(source);
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
