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
        public ParamViewModel()
        {
            Sec = new ObservableCollection<List_Sec>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public ObservableCollection<List_Sec> Sec { get; set; }
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
