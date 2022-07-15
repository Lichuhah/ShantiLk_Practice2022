using Newtonsoft.Json;
using ShantiLk.Api.Models.Common.Profile;
using ShantiLk.Api.Models.Domain.Profile;

namespace ShantiLk.Api.Controllers
{
    public partial class ProfileController
    {
        private async Task<ProfileData> h_GetProfile()
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            HttpResponseMessage resp = client.Get("https://pro.guap.ru/inside_s").Result;
            string result = resp.Content.ReadAsStringAsync().Result;
            int i = result.IndexOf("user_id") + 10;
            int i2 = result.IndexOf(",", i) - 1;
            string profileid = result.Substring(i, i2 - i);
            resp = client.Get("https://pro.guap.ru/getstudentprofile/" + profileid).Result;
            result = resp.Content.ReadAsStringAsync().Result;
            return (JsonConvert.DeserializeObject<ProfileAnswer>(result)).user;
        }
    }
}
