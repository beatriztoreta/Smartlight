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
                
        public GraphicsViewModel()
        {
            BarrasCommand = new Command(async () => await ExecuteLoadBarrasCommand());
            PizzaCommand = new Command(async () => await ExecuteLoadPizzaCommand());
        }
        
        public Graphics_Data Barras { get; set; }

        public Graphics_Data Pizza { get; set; }

        public async Task ExecuteLoadBarrasCommand()
        {
            IsBusy = true;
            
            try
            {
                int min = 0;
                int max = 0;
                
                Barras = new Graphics_Data();
                
                var items = await Data_Graphics_Store.GetItemAsync("proto");
                
                foreach (var item in (items as Graph_aux).aux)
                {
                    min += item.min;
                    max += item.max;
                }

                Barras.max = max;
                Barras.min = min;

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

        public async Task ExecuteLoadPizzaCommand()
        {
            IsBusy = true;

            try
            {
                int min = 0;
                int max = 0;

                Pizza = new Graphics_Data();

                var items = await Data_Graphics_Store.GetItemAsync("proto");

                foreach (var item in (items as Graph_aux).aux)
                {
                    min += item.min;
                    max += item.max;
                }

                Pizza.max = max;
                Pizza.min = min;

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

    }
}
