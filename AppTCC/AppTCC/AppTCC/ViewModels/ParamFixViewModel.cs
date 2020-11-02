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
    public class ParamFixViewModel : BaseViewModel
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

        public ParamFixViewModel(int tag)
        {
            sector_tag = tag;
            
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
                Obj_Sector newItem = new Obj_Sector()
                {
                    sector_tag = Sector_tag,
                    min_intensity = Min,
                    max_intensity = Max
                };

                await Data_Param_Store.AddItemAsync(newItem);

                CrossToastPopUp.Current.ShowToastMessage("Paramentros enviados com sucesso!", ToastLength.Long);
            }
            else
                CrossToastPopUp.Current.ShowToastMessage("Preencha os campos!", ToastLength.Long);
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

    }
}
