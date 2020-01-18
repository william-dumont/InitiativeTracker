using DataLayer.Models;
using InitiativeTracker.Other;
using InitiativeTracker.Pages;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InitiativeTracker.Startup
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new InitiativeTrackerPage();
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
