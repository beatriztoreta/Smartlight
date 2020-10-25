﻿using AppTCC.Views;
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
            BarrasCommand = new Command(async () => await ExecuteLoadItemsCommand());
            PizzaCommand = new Command(async () => await ExecuteLoadItemsCommand());
            
        }
        
        public ObservableCollection<Graphics_Data> Barras { get; set; }
       
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            
            try
            {
                Barras.Clear();

                Graphics_Data item = await Data_Graphics_Store.GetItemAsync("proto");

                Barras.Add(item);

                
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
