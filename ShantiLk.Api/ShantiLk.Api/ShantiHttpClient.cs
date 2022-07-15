using Newtonsoft.Json;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace ShantiLk.Api
{
    public class ShantiHttpClient
    {
        ClaimsPrincipal User { get; set; }
        public CookieContainer CookieContainer { get; set; }
        public StringContent Body { get; set; }
        public ShantiHttpClient()
        {
            CookieContainer = new CookieContainer();
        }
        public ShantiHttpClient(ClaimsPrincipal user)
        {
            User = user;
            CookieContainer = new CookieContainer();
        }

        public void AddCookie(string name, string value)
        {
            CookieContainer.Add(new Cookie(name, value, "/", ""));
        }

        public void SetBody(object item)
        {
            Body = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
        }

        private HttpClient CreateClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            if (User != null)
            {
                var claims = User.Claims.Select(x => x.Value).ToList();
                AddCookie("SessionId", claims[1]);
                AddCookie("SharedId", claims[2]);
            }
            if (CookieContainer.Count > 0)
                clientHandler.CookieContainer = CookieContainer;
            return new HttpClient(clientHandler);

        }
        public async Task<HttpResponseMessage> Get(string url)
        {
            HttpClient client = CreateClient();
            HttpResponseMessage responce = await client.GetAsync(url);
            if (responce.IsSuccessStatusCode)
                return responce;
            else throw new Exception(responce.StatusCode.ToString());
        }

        public async Task<HttpResponseMessage> Post(string url)
        {
            HttpClient client = CreateClient();
            var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = Body != null ? Body : new StringContent("") };
            HttpResponseMessage responce = await client.SendAsync(req);
            if (responce.IsSuccessStatusCode)
                return responce;
            else throw new Exception(responce.StatusCode.ToString());
        }
    }
}
