using Newtonsoft.Json;
using ShantiLk.Api.Models.ShantiClasses.Dict;
using ShantiLk.Api.Models.ShantiClasses.Domain;
using ShantiLk.Api.Models.SuaiClasses.Answers;

namespace ShantiLk.Api.Controllers
{
    public partial class MaterialController
    {
        private async Task<List<Material>> h_GetMaterials(int? SemesterId)
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            client.AddFormEncoded("iduser", "0");
            HttpResponseMessage resp = client.Post("https://pro.guap.ru/getstudentmaterialdictionaries/").Result;
            string result = resp.Content.ReadAsStringAsync().Result;
            MaterialAnswer answer = JsonConvert.DeserializeObject<MaterialAnswer>(result);

            if (SemesterId != null)
            {
                client.AddFormEncoded("semester", SemesterId.ToString());
                client.AddFormEncoded("subject", "0");
                resp = client.Post("https://pro.guap.ru/getstudentmaterials/").Result;
                answer.Materials = JsonConvert.DeserializeObject<MaterialAnswer>(resp.Content.ReadAsStringAsync().Result).Materials;
            }     
            
            return answer.Materials.Select(x => new Material()
            {
                Id = x.Id,
                Name = x.Name,
                CreatedDate = x.CreatedDate,
                Url = x.Url,
                FileLink = x.FileLink,
                Semester = new Semester
                {
                    Id = x.SemesterId,
                    Name = answer.Dictionares.Semesters.FirstOrDefault(y => y.Id == x.SemesterId).Name
                },
                Subject = new Subject()
                {
                    Id = x.SubjectIdsArray[0],
                    Name = answer.Dictionares.Subjects.FirstOrDefault(y => y.Id == x.SubjectIdsArray[0]).Name
                }
            }).ToList();
        }
    }
}
