using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using AppTCC.Views;
using System.Threading.Tasks;
using Plugin.Toast;
using Plugin.Toast.Abstractions;

namespace AppTCC.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public Command AboutCommand { get; }

        public AboutViewModel()
        {
            Title = "About";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
            AboutCommand = new Command(OnAboutClicked);
        }

        //public ICommand OpenWebCommand { get; }

        private async void OnAboutClicked(object obj)
        {
            CrossToastPopUp.Current.ShowToastMessage("Álisson H. P. Kawachi - RA 081160011 " +
                                                     "Amanda Guttierres. Ruza - RA 081160013 " +
                                                     "Beatriz Toreta Pereira - RA 081160002            " +
                                                     "Ivan Zanutto Bastos - RA 081160003", ToastLength.Long);
            //await DisplayAlert("Equipe", "Álisson H. P. Kawachi - RA 081160011 /n Amanda G. Ruza - RA 081160013 /n Beatriz T. Pereira - RA 081160002 /n Ivan Z. Bastos - RA 081160003", "OK");
        }

        private Task DisplayAlert(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
    }
}