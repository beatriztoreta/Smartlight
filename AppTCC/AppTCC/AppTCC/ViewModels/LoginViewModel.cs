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


namespace AppTCC.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string user;
        private string password;

        public Command LoginCommand { get; }

       public LoginViewModel()
       {
            //LoginCommand = new Command(OnLoginClicked);

            //FetchData();

            LoginCommand = new Command(OnSave, ValidateSave);

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
            Person newItem = new Person()
            {
                _id = Convert.ToInt32(Guid.NewGuid().ToString()),
                user = User,
                password = Password
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnLoginClicked(object obj)
        {
            Person newItem = new Person()
            {
                _id = Convert.ToInt32(Guid.NewGuid()),
                user = User,
                password = Password
            };

            await MongoService.InsertItem(newItem);

            CrossToastPopUp.Current.ShowToastMessage("Registro efetuado com sucesso!", ToastLength.Long);
        }

        public IEnumerable<object> Data { get; private set; }

        private async Task FetchData() 
        {
            var credentials = new Amazon.CognitoIdentity.CognitoAWSCredentials("us-east-1:45984fda-069a-4c08-bdb7-55c115e90259", Amazon.RegionEndpoint.USEast1);

            var ddbClient = new Amazon.DynamoDBv2.AmazonDynamoDBClient(credentials, Amazon.RegionEndpoint.USEast1);

            ScanRequest request = new ScanRequest
            {
                TableName = "Auth",
                AttributesToGet = new List<string> { "id", "password", "user" }
            };

            var results = await ddbClient.ScanAsync(request);

            Data = results.Items.Select(i => new
            {
                id = i["id"].S,
                user = i["user"].S,
                password = i["password"].S
            }).OrderBy(i => i.user);

            RaisePropertyChanged(nameof(Data));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
