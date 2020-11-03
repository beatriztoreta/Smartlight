using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using SmartLight.Models;
using SmartLight.Services;

namespace SmartLight.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Person> DataStore => DependencyService.Get<IDataStore<Person>>();

        public IDataStore<Entity> Data_Entities_Store => DependencyService.Get<IDataStore<Entity>>();

        public IDataStore<Graph_aux> Data_Graphics_Store => DependencyService.Get<IDataStore<Graph_aux>>();

        public IDataStore<Graph_Entity> Data_Graphics_Eficien_Store => DependencyService.Get<IDataStore<Graph_Entity>>();

        public IDataStore<Graph_Finan> Data_Graphics_Finan_Store => DependencyService.Get<IDataStore<Graph_Finan>>();

        public IDataStore<Obj_Sector> Data_Param_Store => DependencyService.Get<IDataStore<Obj_Sector>>();

        public IDataStore<Sector_status_aux> Data_Monitor_Store => DependencyService.Get<IDataStore<Sector_status_aux>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
