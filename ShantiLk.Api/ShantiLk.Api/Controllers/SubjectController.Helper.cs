using Newtonsoft.Json;
using ShantiLk.Api.Models.ShantiClasses.Dict;
using ShantiLk.Api.Models.ShantiClasses.Subject;
using ShantiLk.Api.Models.SuaiClasses.Answers;

namespace ShantiLk.Api.Controllers
{
    public partial class SubjectController
    {
        private async Task<List<SubjectListItem>> h_GetSubjects()
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            client.AddFormEncoded("iduser", "0");
            HttpResponseMessage resp = client.Post("https://pro.guap.ru/getsubjectsdictionaries/").Result;
            string result = resp.Content.ReadAsStringAsync().Result;
            s_SubjectAnswer answer = JsonConvert.DeserializeObject<s_SubjectAnswer>(result);;
            return answer.Subjects.Select(x => new SubjectListItem()
            {
                Id = x.Id,
                Name = x.Name,
                Messages = x.Messages,
                CountMessages = x.NewMessagesCount,
                ControlType = new Models.SuaiClasses.Dict.s_DictControlType
                {
                    Id = x.ControlTypeId,
                    Name = x.ControlTypeName
                },
                Semester = new DictSemester()
                {
                    Id = x.SemesterNumber,
                    Name = x.SemesterName
                },
                Teachers = x.Teachers
            }).ToList();
        }
    }
}
