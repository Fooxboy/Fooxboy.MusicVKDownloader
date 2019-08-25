using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.MusicVKDownloader.Services
{
    public class TokenService
    {
        /// <summary>
        /// Получение текущего токена пользователя.
        /// </summary>
        /// <returns>Ключ доступа, если его нет, тогда возращается null</returns>
        public async Task<string> GetCurrentToken()
        {
            //TODO: получение токена.
            return "";
        }

        /// <summary>
        /// Устанавливается токен текущего пользователя.
        /// </summary>
        /// <param name="token">Ключ доступа</param>
        /// <returns></returns>
        public async Task SetCurrentToken(string token)
        {
            //TODO: Установка токена.
        }

        /// <summary>
        /// Удаляет токен текущего пользователя, если он есть.
        /// </summary>
        /// <returns></returns>
        public async Task ClearToken()
        {
            //TODO: очищение токена.
        }
    }
}
