using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Fooxboy.MusicVKDownloader.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;

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

        private LoginService loginService;
        public LoginViewModel()
        {
            loginService = SimpleIoc.Default.GetInstance<LoginService>();
            LoginCommand = new RelayCommand(async() =>
            {
                IsLoading = true;
                if(Login == "" || Password == "")
                {
                    //TODO: Неверный логин или пароль.
                    return;
                }

                try
                {
                    await loginService.Auth(Login, Password);
                }
                catch (VkNet.Exception.UserAuthorizationFailException)
                {
                   
                }
                catch (VkNet.Exception.VkAuthorizationException)
                {
                    
                }
                catch (VkNet.Exception.VkApiAuthorizationException)
                {
                   
                }
                catch (VkNet.Exception.UserDeletedOrBannedException)
                {
                   
                }catch(VkNet.Exception.AccessTokenInvalidException)
                {

                }catch(VkNet.Exception.NeedValidationException e)
                {

                }catch(Exception e)
                {

                }

            });
        }
    }
}
