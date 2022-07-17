using Newtonsoft.Json;
using ShantiLk.Api.Models.ShantiClasses.Dict;
using ShantiLk.Api.Models.ShantiClasses.Material;
using ShantiLk.Api.Models.SuaiClasses.Answers;

namespace ShantiLk.Api.Controllers
{
    public partial class MaterialController
    {
        private async Task<List<Material>> h_GetMaterials(int? SemesterId=0, int? SubjectId=0)
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            client.AddFormEncoded("iduser", "0");
            HttpResponseMessage resp = client.Post("https://pro.guap.ru/getstudentmaterialdictionaries/").Result;
            string result = resp.Content.ReadAsStringAsync().Result;
            s_MaterialAnswer answer = JsonConvert.DeserializeObject<s_MaterialAnswer>(result);

            if (SemesterId != 0 || SubjectId != 0)
            {
                client.AddFormEncoded("semester", SemesterId.ToString());
                client.AddFormEncoded("subject", SubjectId.ToString());
                resp = client.Post("https://pro.guap.ru/getstudentmaterials/").Result;
                answer.Materials = JsonConvert.DeserializeObject<s_MaterialAnswer>(resp.Content.ReadAsStringAsync().Result).Materials;
            }

            return answer.Materials.Select(x => new Material()
            {
                Id = x.Id,
                Name = x.Name,
                CreatedDate = x.CreatedDate,
                Url = x.Url,
                FileHash = x.FileLink.Substring(11),
                Semester = new DictSemester
                {
                    Id = x.SemesterId,
                    Name = answer.Dictionares.Semesters.FirstOrDefault(y => y.Id == x.SemesterId).Name
                },
                Subject = new DictSubject()
                {
                    Id = x.SubjectIdsArray[0],
                    Name = answer.Dictionares.Subjects.FirstOrDefault(y => y.Id == x.SubjectIdsArray[0]).Name
                }
            }).ToList();
        }

        private async Task<byte[]> h_GetFile(string FileHash)
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            HttpResponseMessage resp = client.Get("https://pro.guap.ru/get-material/"+FileHash).Result;
            byte[] result = resp.Content.ReadAsByteArrayAsync().Result;

            return result;
        }
    }
}
