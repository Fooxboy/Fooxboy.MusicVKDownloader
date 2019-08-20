using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Fooxboy.MusicVKDownloader.ViewModels
{
    public class LoginViewModel:ViewModelBase
    {
        private bool isLoading = false;
        private string login = "";
        private string password = "";


        public bool IsLoading
        {
            get => isLoading;
            set
            {
                if (value == isLoading) return;
                isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }

        public string Login
        {
            get => login;
            set
            {
                if (value == login) return;
                login = value;
                RaisePropertyChanged("Login");
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (value == password) return;
                password = value;

                RaisePropertyChanged("Password");
            }
        }

        public ICommand LoginCommand { get; private set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(() =>
            {
                //TODO: вход в аккаунт
            });
        }
    }
}
