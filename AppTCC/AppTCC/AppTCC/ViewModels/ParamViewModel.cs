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

namespace AppTCC.ViewModels
{
    public class ParamViewModel : BaseViewModel
    {
        public Command ParamCommand { get; }

       public ParamViewModel()
       {
            //ParamCommand = new Command();
       }
  
    }
}
