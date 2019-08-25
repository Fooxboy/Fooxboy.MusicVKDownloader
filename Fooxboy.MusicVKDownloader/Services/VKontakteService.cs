using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model;
using VkNet.Utils.AntiCaptcha;

namespace Fooxboy.MusicVKDownloader.Services
{
    /// <summary>
    /// Сервис для работы с ВКонтакте
    /// </summary>
    public class VKontakteService
    {
        public VkApi Api { get; private set; }
        private ICaptchaSolver captchaSolver;
        private Func<string> twoAuth = () =>
        {
            throw new Exception("Двухфакторная авторизация не реализована.");
        };

        /// <summary>
        /// Установка экзепляра класса работы с API
        /// </summary>
        /// <param name="api">Экземпляр класса API</param>
        public void SetApi(VkApi api)
        {
            if (Api == null) Api = api;
        }

        /// <summary>
        /// Установка экземпляра класса для обработки капчи.
        /// </summary>
        /// <param name="captchaSolver">Реализация captchaSolver</param>
        public void SetCaptchaSolver(ICaptchaSolver captchaSolver) => this.captchaSolver = captchaSolver;
        public void SetTwoAuth(Func<string> twoAuth) => this.twoAuth = twoAuth;

        /// <summary>
        /// Авторизация во ВКонтакте с помощью Access Token
        /// </summary>
        /// <param name="token">Access Token</param>
        /// <returns></returns>
        public async Task AuthToken(string token)
        {
            var services = new ServiceCollection();
            services.AddAudioBypass();
            var api = new VkApi(services);

            await api.AuthorizeAsync(new ApiAuthParams()
            {
                AccessToken = token
            });
            api.CaptchaSolver = this.captchaSolver;
            SetApi(api);
        }

        /// <summary>
        /// Авторизация Во Вконтакте по логину и паролю.
        /// </summary>
        /// <param name="login">Номер телефона или адрес электронной почты</param>
        /// <param name="password">Пароль</param>
        /// <returns>Ключ доступа</returns>
        public async Task<string> AuthLogin(string login, string password)
        {
            var services = new ServiceCollection();
            services.AddAudioBypass();
            var api = new VkApi(services);

            await api.AuthorizeAsync(new ApiAuthParams()
            {
                Login = login,
                Password = password,
                TwoFactorAuthorization = twoAuth
            });

            SetApi(api);
            return api.Token;
        }

        /// <summary>
        /// Авторизация Во Вконтакте по логину и паролю.
        /// </summary>
        /// <param name="login">Номер телефона или адрес электронной почты</param>
        /// <param name="password">Пароль</param>
        /// <param name="twoFactorAuth">Двухфакторная авторизация</param>
        /// <returns>Ключ доступа</returns>
        public async Task<string> AuthLogin(string login, string password, Func<string> twoFactorAuth)
        {
            SetTwoAuth(twoFactorAuth);
            var token = await AuthLogin(login, password);
            return token;
        }
    }
}
