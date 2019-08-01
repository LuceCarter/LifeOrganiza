using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;
using MyFirstPrettyApp.Views;


namespace MyFirstPrettyApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand LogoutCommand { get; }
        public MainPageViewModel()
        {
            LogoutCommand = new Command(() => logout());
        }

        private void logout()
        {
            App.IsLoggedIn = false;
            App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
    }
}