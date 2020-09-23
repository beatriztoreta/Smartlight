using AppTCC.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using AppTCC;
using Plugin.Toast;

namespace AppTCC.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string user;
        private string password;

        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
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

        private async void OnLoginClicked(object obj)
        {
            Application.Current.MainPage = new AboutPage();
        }
    }
}
