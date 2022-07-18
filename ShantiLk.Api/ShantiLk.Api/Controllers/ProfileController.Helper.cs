using Newtonsoft.Json;
using ShantiLk.Api.Models.ShantiClasses.Profile;
using ShantiLk.Api.Models.SuaiClasses.Answers;
using System.Security.Claims;

namespace ShantiLk.Api.Controllers
{
    public partial class ProfileController
    {
        private async Task<ProfileInfo> h_GetProfile()
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            HttpResponseMessage resp = client.Get("https://pro.guap.ru/inside_s").Result;
            string result = resp.Content.ReadAsStringAsync().Result;
            string profileid = string.Empty;
            if (HttpContext.User.Claims.Where(x=>x.Type == ClaimTypes.SerialNumber).Any())
            {
                profileid = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.SerialNumber).First().Value;
            } else
            {
                int i = result.IndexOf("user_id") + 10;
                int i2 = result.IndexOf(",", i) - 1;
                profileid = result.Substring(i, i2 - i);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.SerialNumber, profileid)
                };
                var appIdentity = new ClaimsIdentity(claims);
                HttpContext.User.AddIdentity(appIdentity);
            }
            resp = client.Get("https://pro.guap.ru/getstudentprofile/" + profileid).Result;
            result = resp.Content.ReadAsStringAsync().Result;
            s_ProfileAnswer answer = JsonConvert.DeserializeObject<s_ProfileAnswer>(result);
            return new ProfileInfo
            {
                IdProfile = answer.User.Id,
                IdStudent = answer.Student.Id,
                Email = answer.User.Email,
                Phone = answer.User.Phone,
                Name = answer.User.Name,
                MiddleName = answer.User.MiddleName,
                LastName = answer.User.LastName,
                EducationPlanHash = answer.EducationPlan.Hash
            };
        }

        private async Task<byte[]> h_GetEducationPlan()
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            string hash = h_GetProfile().Result.EducationPlanHash;
            HttpResponseMessage resp = client.Get("https://pro.guap.ru/get-student-eduplan/" + hash).Result;
            byte[] result = resp.Content.ReadAsByteArrayAsync().Result;

            return result;
        }
    }
}