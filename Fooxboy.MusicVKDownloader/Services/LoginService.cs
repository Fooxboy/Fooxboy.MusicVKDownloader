using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.MusicVKDownloader.Services
{
    /// <summary>
    /// Сервис для входа в аккаунт ВКонтакте
    /// </summary>
    public class LoginService
    {
        /// <summary>
        /// Первая авторизация по логину и паролю
        /// </summary>
        /// <param name="login">Номер телефона или адрес электронной почты</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public async Task Auth(string login, string password)
        {
            
        }

        /// <summary>
        /// Автоматическая авторизация при запуске приложения, если пользователь уже вошел в аккаунт.
        /// </summary>
        /// <param name="accessToken">Ключ доступа</param>
        /// <returns></returns>
        public async Task AutoAuth(string accessToken)
        {
            
        }
    }
}
