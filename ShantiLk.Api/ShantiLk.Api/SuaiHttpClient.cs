using System.Net;

namespace ShantiLk.Api
{
    public class SuaiHttpClient
    {
        public CookieContainer CookieContainer { get; set; }
        public FormUrlEncodedContent FormUrlEncodedContent { get; set; }
        public List<KeyValuePair<string, string>> EncodedValues { get; set; }

        public SuaiHttpClient()
        {
            CookieContainer = new CookieContainer();
            EncodedValues = new List<KeyValuePair<string, string>>();
        }

        public void AddCookie(string name, string value)
        {
            CookieContainer.Add(new Cookie(name, value, "/", ".guap.ru"));
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
    }
}
