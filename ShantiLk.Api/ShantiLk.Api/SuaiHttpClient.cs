using System.Net;
using System.Security.Claims;

namespace ShantiLk.Api
{
    public class SuaiHttpClient
    {
        private CookieContainer CookieContainer { get; set; }
        private FormUrlEncodedContent FormUrlEncodedContent { get; set; }

        private MultipartFormDataContent FormDataContent { get; set; }
        private List<KeyValuePair<string, string>> EncodedValues { get; set; }

        public SuaiHttpClient()
        {
            CookieContainer = new CookieContainer();
            EncodedValues = new List<KeyValuePair<string, string>>();
            FormDataContent = new MultipartFormDataContent();
        }

        public SuaiHttpClient(ClaimsPrincipal user)
        {
            CookieContainer = new CookieContainer();
            var claims = user.Claims.Select(x => x.Value).ToList();
            AddCookie("PHPSESSID", claims[1]);
            AddCookie("sharedsessioID", claims[2]);
            EncodedValues = new List<KeyValuePair<string, string>>();
            FormDataContent = new MultipartFormDataContent();
        }

        public void AddCookie(string name, string value)
        {
            CookieContainer.Add(new Cookie(name, value, "/", ".guap.ru"));
        }

        public void AddFormData(string data, string key)
        {
            FormDataContent.Add(new StringContent(data), key);
            
        }

        public void AddFile(byte[] data, string key, string filename)
        {
                FormDataContent.Add(new ByteArrayContent(data), key, filename);
        }

        public void AddFormEncoded(string name, string value)
        {
            EncodedValues.Add(new KeyValuePair<string, string>(name, value));
        }

        private HttpClient CreateClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.AllowAutoRedirect = false;
            if (CookieContainer.Count > 0)
                clientHandler.CookieContainer = CookieContainer;
            return new HttpClient(clientHandler);

        }
        public async Task<HttpResponseMessage> Get(string url)
        {
            HttpClient client = CreateClient();
            HttpResponseMessage responce = await client.GetAsync(url);
            if (responce.IsSuccessStatusCode || responce.StatusCode == HttpStatusCode.Found)
                return responce;
            else throw new Exception(responce.StatusCode.ToString());
        }

        public async Task<HttpResponseMessage> Post(string url)
        {
            HttpClient client = CreateClient();
            FormUrlEncodedContent = new FormUrlEncodedContent(EncodedValues);
            var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = FormUrlEncodedContent };
            HttpResponseMessage responce = await client.SendAsync(req);
            if (responce.IsSuccessStatusCode || responce.StatusCode == HttpStatusCode.Found)
                return responce;
            else throw new Exception(responce.StatusCode.ToString());
        }

        public async Task<HttpResponseMessage> PostFile(string url)
        {
            HttpClient client = CreateClient();
            var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = this.FormDataContent };
            HttpResponseMessage responce = await client.SendAsync(req);
            if (responce.IsSuccessStatusCode || responce.StatusCode == HttpStatusCode.Found)
                return responce;
            else throw new Exception(responce.StatusCode.ToString());
        }

        public async Task<HttpResponseMessage> Delete(string url)
        {
            HttpClient client = CreateClient();
            var req = new HttpRequestMessage(HttpMethod.Delete, url);
            HttpResponseMessage responce = await client.SendAsync(req);
            if (responce.IsSuccessStatusCode)
                return responce;
            else throw new Exception(responce.StatusCode.ToString());
        }
    }
}
