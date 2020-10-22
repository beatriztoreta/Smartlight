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
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace AppTCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private Person p = new Person();
        public ListView l = new ListView();
        public ObservableCollection<Person> Items { get; }

        public bool aux = false;
        
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
            Items = new ObservableCollection<Person>();
        }
        
        async void UserBackup()
        {
            await App.Database.SavePersonAsync(new Person
            {
                _id = Guid.NewGuid().ToString(),
                user = "teste",
                password = "teste"
            });

            await App.Database.SavePersonAsync(new Person
            {
                _id = Guid.NewGuid().ToString(),
                user = "pops",
                password = "popoya"
            });

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
            await App.Database.SavePersonAsync(new Person
            {
                _id = Guid.NewGuid().ToString(),
                user = "teste",
                password = "teste"
            });

            await App.Database.SavePersonAsync(new Person
            {
                _id = Guid.NewGuid().ToString(),
                user = "pops",
                password = "popoya"
            });

            aux = false;

            if (!string.IsNullOrWhiteSpace(userEntry.Text) && !string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                await ExecuteLoadItemsCommand();

                foreach (var person in Items)
                {
                    if (userEntry.Text == person.user && passwordEntry.Text == person.password)
                    {
                        aux = true;

                        CrossToastPopUp.Current.ShowToastMessage("Login efetuado com sucesso!", ToastLength.Long);

                        await Navigation.PushAsync(new AboutPage());
                    }
                }
                if (aux == false)
                {
                    CrossToastPopUp.Current.ShowToastMessage("Preencha os campos corretamente!", ToastLength.Long);
                }

            }
            else
            {
                CrossToastPopUp.Current.ShowToastMessage("Preencha os campos corretamente!", ToastLength.Long);
            }
            
        }

        async Task ExecuteLoadItemsCommand()
        {
            try
            {
                Items.Clear();
                var items = await App.Database.GetPeopleAsync();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            
        }

    }
}