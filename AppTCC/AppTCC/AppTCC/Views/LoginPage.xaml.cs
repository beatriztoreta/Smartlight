using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTCC.ViewModels;
using AppTCC.Models;
using AppTCC.Services;
using Plugin.Toast;
using Plugin.Toast.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private Person p = new Person();
        public ListView l = new ListView();

        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

       async void OnRegisterClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(userEntry.Text) && !string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                await App.Database.SavePersonAsync(new Person
                {
                    user = userEntry.Text,
                    password = passwordEntry.Text
                });

                p.user = userEntry.Text;
                p.password = passwordEntry.Text;
                userEntry.Text = passwordEntry.Text = string.Empty;
                
                CrossToastPopUp.Current.ShowToastMessage("Registro efetuado com sucesso!", ToastLength.Long);

                await Navigation.PushAsync(new AboutPage());
            }

        }

        async void OnLoginClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(userEntry.Text) && !string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                await App.Database.SavePersonAsync(new Person
                {
                    user = userEntry.Text,
                    password = passwordEntry.Text
                });

                p.user = userEntry.Text;
                p.password = passwordEntry.Text;
                userEntry.Text = passwordEntry.Text = string.Empty;
                
                CrossToastPopUp.Current.ShowToastMessage("Login efetuado com sucesso!", ToastLength.Long);

                await Navigation.PushAsync(new AboutPage());
            }

        }
    }
}