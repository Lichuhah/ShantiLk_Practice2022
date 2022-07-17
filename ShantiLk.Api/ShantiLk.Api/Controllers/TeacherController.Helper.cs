using Newtonsoft.Json;
using ShantiLk.Api.Models.ShantiClasses.Teacher;
using ShantiLk.Api.Models.SuaiClasses.Answers;

namespace ShantiLk.Api.Controllers
{
    public partial class TeacherController
    {
        private async Task<Teacher> h_GetTeacher(int id)
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            HttpResponseMessage resp = client.Get("https://pro.guap.ru/getuserprofile/" + id.ToString()).Result;
            string result = resp.Content.ReadAsStringAsync().Result;
            s_TeacherAnswer answer = JsonConvert.DeserializeObject<s_TeacherAnswer>(result);
            return new Teacher()
            {
                Id = answer.Teacher.Id,
                Name = answer.Teacher.Name,
                MiddleName = answer.Teacher.MiddleName,
                LastName = answer.Teacher.LastName,
                Auditory = answer.Teacher.Auditorium,
                Email = answer.Teacher.Email,
                Phone = answer.Teacher.Phone,
                Works = answer.Teacher.Works.Select(x=> new TeacherWork
                {
                    PositionName = x.PostName,
                    WorkPlace = x.DepartmentName,
                    Department = x.FacultyShortName
                }).ToList(),
                Disciplines = answer.Subjects
            };
        }
    }
}
