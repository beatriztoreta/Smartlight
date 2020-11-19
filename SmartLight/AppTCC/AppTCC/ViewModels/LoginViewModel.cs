using System;
using Xamarin.Forms;
using Plugin.Toast;
using SmartLight.Models;
using Plugin.Toast.Abstractions;
using SmartLight.Views;

namespace SmartLight.ViewModels
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
                        //await Shell.Current.GoToAsync("//DashboardPage");
                        Application.Current.MainPage = new NavigationPage(new DashboardPage());
                    }
                    else
                    {
                        CrossToastPopUp.Current.ShowToastMessage("Login efetuado com sucesso!", ToastLength.Long);
                        //await Shell.Current.GoToAsync("//DashboardOperPage");
                        Application.Current.MainPage = new NavigationPage(new DashboardOperPage());
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
