using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyFirstPrettyApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; }
      

        public LoginPageViewModel()
        {
            LoginCommand = new Command(() => login());
        }


        private string usernameText;

        public string UsernameEntryText
        {
            get => usernameText;
            set => SetProperty(ref usernameText, value);
        }

        private string passwordText;

        public string PasswordEntryText
        {
            get => passwordText;
            set => SetProperty(ref passwordText, value);
        }

        private bool isLoginVisible = false;

        public bool IsLoginFailedVisible
        {
            get => isLoginVisible;
            set => SetProperty(ref isLoginVisible, value);
        }

        private void login()
        {
            if(UsernameEntryText.Equals("user") && PasswordEntryText.Equals("password"))
            {
                IsLoginFailedVisible = false;
                App.IsLoggedIn = true;
                App.Current.MainPage = new AppShell();
            }
            
            else
            {
                UsernameEntryText = string.Empty;
                PasswordEntryText = string.Empty;
            }
        }
    }
}
