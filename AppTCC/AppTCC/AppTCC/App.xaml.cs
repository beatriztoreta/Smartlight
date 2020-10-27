﻿using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppTCC.Views;
using AppTCC.ViewModels;
using AppTCC.Services;
using Xamarin.Forms.Internals;
using System.Diagnostics;

namespace AppTCC
{
    public partial class App : Application
    {
        static Database database;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            Xamarin.Forms.Internals.Log.Listeners.Add(new DelegateLogListener((arg1, arg2) => Debug.WriteLine(arg2)));

            DependencyService.Register<ApiPeopleDataStore>();
            DependencyService.Register<ApiEntitiesDataStore>();
            DependencyService.Register<ApiGraphicsDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
