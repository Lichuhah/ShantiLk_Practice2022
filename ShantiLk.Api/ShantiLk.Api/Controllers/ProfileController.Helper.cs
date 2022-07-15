using Newtonsoft.Json;
using ShantiLk.Api.Models.ShantiClasses.Domain;
using ShantiLk.Api.Models.SuaiClasses.Answers;

namespace ShantiLk.Api.Controllers
{
    public partial class ProfileController
    {
        private async Task<ProfileInfo> h_GetProfile()
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            HttpResponseMessage resp = client.Get("https://pro.guap.ru/inside_s").Result;
            string result = resp.Content.ReadAsStringAsync().Result;
            int i = result.IndexOf("user_id") + 10;
            int i2 = result.IndexOf(",", i) - 1;
            string profileid = result.Substring(i, i2 - i);
            resp = client.Get("https://pro.guap.ru/getstudentprofile/" + profileid).Result;
            result = resp.Content.ReadAsStringAsync().Result;
            ProfileAnswer answer = JsonConvert.DeserializeObject<ProfileAnswer>(result);
            return new ProfileInfo
            {
                IdProfile = answer.User.Id,
                IdStudent = answer.Student.Id,
                Email = answer.User.Email,
                Phone = answer.User.Phone,
                Name = answer.User.Name,
                MiddleName = answer.User.MiddleName,
                LastName = answer.User.LastName
            };
        }
    }
}
