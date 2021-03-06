﻿using FirstXamarinApp.Services;
using FirstXamarinApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstXamarinApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDogStore>();
            DependencyService.Register<MockDogVoteStore>();
            DependencyService.Register<MockColourVoteStore>();
            DependencyService.Register<MockDataStore>();
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
