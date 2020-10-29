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
using System.Windows.Input;
using Android.Content.Res;

namespace AppTCC.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string user;
        private string password;

        public Command LoginCommand { get; }

        public LoginViewModel()
       {
            LoginCommand = new Command(OnSave);

            this.PropertyChanged += (_, __) => LoginCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(user)
                && !String.IsNullOrWhiteSpace(password);
        }

        public string User
        {
            get => user;
            set => SetProperty(ref user, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private async void OnSave()
        {
            if (ValidateSave() == true)
            {
                Person p = new Person();
                p.user = user;
                p.password = password;

                Person pessoa = await DataStore.AddItemRetAsync(p);

                if (pessoa != null)
                {
                    if (pessoa.permission == "dir")
                    {
                        CrossToastPopUp.Current.ShowToastMessage("Login efetuado com sucesso!", ToastLength.Long);
                        await Shell.Current.GoToAsync("//DashboardPage");
                    }
                    else
                    {
                        CrossToastPopUp.Current.ShowToastMessage("Login efetuado com sucesso!", ToastLength.Long);
                        await Shell.Current.GoToAsync("//DashboardOperPage");
                    }
                }
                else
                    CrossToastPopUp.Current.ShowToastMessage("Preencha os campos corretamente!", ToastLength.Long);
            }
            else
                CrossToastPopUp.Current.ShowToastMessage("Preencha os campos corretamente!", ToastLength.Long);

        }

    }
}
