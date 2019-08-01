using MyFirstPrettyApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFirstPrettyApp
{
    public partial class App : Application
    {
        public static bool IsLoggedIn = false;
        public App()
        {
            InitializeComponent();


            if(!IsLoggedIn)
            {
                MainPage = new LoginPage();
            }

            else
            {
                MainPage = new AppShell();
            }
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
