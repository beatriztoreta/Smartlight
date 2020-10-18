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

namespace AppTCC.ViewModels
{
    public class ParamViewModel : BaseViewModel
    {
        private int min;
        private int max;

        public Command ParamCommand { get; }

       public ParamViewModel()
       {
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
                Person newItem = new Person()
                {
                    _id = Guid.NewGuid().ToString(),
                    user = User,
                    password = Password
                };

                await Data_Entities_Store.AddItemAsync(newItem);

                await Shell.Current.GoToAsync("..");

                CrossToastPopUp.Current.ShowToastMessage("Paramentros enviados com sucesso!", ToastLength.Long);
            }
            else
                CrossToastPopUp.Current.ShowToastMessage("Preencha os campos!", ToastLength.Long);

        }
    }
}
