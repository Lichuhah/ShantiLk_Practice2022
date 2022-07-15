using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ShantiLk.Api.Models.Common.Auth;
using System.Security.Claims;

namespace ShantiLk.Api.Controllers
{
    public partial class AuthController
    {
        private async Task<bool> h_Login(LoginData data)
        {
            SuaiHttpClient client = new SuaiHttpClient();
            var responce = await client.Get("https://pro.guap.ru/exters/");
            string sessionid = responce.Headers.SingleOrDefault(header => header.Key == "Set-Cookie").Value.First().Split(';')[0].Substring(10);
            sessionid = GetSessionId(data.Login, data.Password, sessionid).Result;
            string sharedid = GetSharedId(sessionid).Result;
            return Authorization(data, new CookieData { SessionId = sessionid, SharedId = sharedid }).Result;
        }

        private async Task<bool> h_Logout()
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            var responce = await client.Get("https://pro.guap.ru/user/logout");         
            if (responce.StatusCode == System.Net.HttpStatusCode.Found)
            {
                HttpContext.SignOutAsync();
                return true;
            } else return false;
        }

        private async Task<bool> h_CheckLogin()
        {
            SuaiHttpClient client = new SuaiHttpClient();
            client.AddCookie("PHPSESSID", Request.Cookies["SessionId"]);
            client.AddCookie("sharedsessioID", Request.Cookies["SharedId"]);
            var responce = await client.Get("https://pro.guap.ru/inside_s");
            if (responce.IsSuccessStatusCode)
            {
                string result = responce.Content.ReadAsStringAsync().Result;
                int i = result.IndexOf("user_id");
                string value = result.Substring(i + 9, result.IndexOf('"', i + 9));
                return true;
            }
            else return false;
        }

        private async Task<string> GetSessionId(string username, string password, string sessionID)
        {
            SuaiHttpClient client = new SuaiHttpClient();
            client.AddCookie("PHPSESSID", sessionID);
            client.AddFormEncoded("_username", username);
            client.AddFormEncoded("_password", password);
            var responce = await client.Post("https://pro.guap.ru/user/login_check");
            var sessid = responce.Headers.SingleOrDefault(header => header.Key == "Set-Cookie").Value;
            return sessid.First().Split(';')[0].Substring(10);
        }

        private async Task<string> GetSharedId(string sessId)
        {
            SuaiHttpClient client = new SuaiHttpClient();
            client.AddCookie("PHPSESSID", sessId);
            var responce = await client.Get("https://pro.guap.ru/login_redirect");
            var sharedId = responce.Headers.SingleOrDefault(header => header.Key == "Set-Cookie").Value;
            return sharedId.First().Split(';')[0].Substring(15);
        }

        private async Task<bool> Authorization(LoginData loginData, CookieData cookieData)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, loginData.Login),
                new Claim(ClaimsIdentity.DefaultNameClaimType, cookieData.SessionId),
                new Claim(ClaimsIdentity.DefaultNameClaimType, cookieData.SharedId)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            try
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            } catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
