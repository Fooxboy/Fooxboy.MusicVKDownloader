using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooxboy.MusicVKDownloader.Services
{
    public class LoginService
    {
        public async Task Auth(string login, string password)
        {
            var token = await Fooxboy.MusicX.Core.VKontakte.Auth.User(login, password, null, null);
        }

        public async Task AutoAuth(string accessToken)
        {
            await Fooxboy.MusicX.Core.VKontakte.Auth.Auto(accessToken, null);
        }
    }
}
