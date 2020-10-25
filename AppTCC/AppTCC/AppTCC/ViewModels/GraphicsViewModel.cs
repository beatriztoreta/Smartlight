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
    public class GraphicsViewModel : BaseViewModel
    {
        public Command BarrasCommand { get; }

        public Command PizzaCommand { get; }

        public Command InfosCommand { get; }

        public GraphicsViewModel()
        {
            source = new List<Entity>();
            Sec = new ObservableCollection<Entity>();

            BarrasCommand = new Command(async () => await ExecuteLoadItemsCommand());
            PizzaCommand = new Command(async () => await ExecuteLoadItemsCommand());
            InfosCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }
        
        public ObservableCollection<Entity> Sec { get; set; }
        readonly IList<Entity> source;
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            
            try
            {
                Sec.Clear();

                Entity item = await Data_Entities_Store.GetItemAsync("proto");
                                
                Sec.Add(item);
                               
                Sec = new ObservableCollection<Entity>(source);
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
