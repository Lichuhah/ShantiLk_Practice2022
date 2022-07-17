using Newtonsoft.Json;
using ShantiLk.Api.Models.ShantiClasses.Dict;
using ShantiLk.Api.Models.ShantiClasses.Subject;
using ShantiLk.Api.Models.SuaiClasses.Answers;
using ShantiLk.Api.Models.SuaiClasses.Subject;

namespace ShantiLk.Api.Controllers
{
    public partial class SubjectController
    {
        private async Task<List<SubjectListItem>> h_GetSubjects(int SemesterId = 0, int ControlTypeId = 0)
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            client.AddFormEncoded("iduser", "0");
            if (SemesterId != 0 || ControlTypeId != 0)
            {
                client.AddFormEncoded("semester", SemesterId.ToString());
                client.AddFormEncoded("controltype", ControlTypeId.ToString());
            }
            HttpResponseMessage resp = client.Post("https://pro.guap.ru/getsubjectsdictionaries/").Result;
            string result = resp.Content.ReadAsStringAsync().Result;
            s_SubjectListAnswer answer = JsonConvert.DeserializeObject<s_SubjectListAnswer>(result);
            return answer.Subjects.Select(x => new SubjectListItem()
            {
                Id = x.Id,
                Name = x.Name,
                CountMessages = x.NewMessagesCount,
                ControlType = new DictControlType
                {
                    Id = x.ControlTypeId,
                    Name = x.ControlTypeName
                },
                Semester = new DictSemester()
                {
                    Id = x.SemesterNumber,
                    Name = x.SemesterName
                },
                Teachers = x.Teachers.Select(y => new DictTeacher
                {
                    Id = y.Id,
                    Name = y.Name,
                    LastName = y.LastName,
                    MiddleName = y.MiddleName
                }).ToList()
            }).ToList();
        }

        private async Task<Subject> h_GetSubject(int SubjectId)
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            client.AddFormEncoded("id", SubjectId.ToString());
            client.AddFormEncoded("eid", HttpContext.User.Claims.Select(x => x.Value).ToList()[0].Substring(2));
            HttpResponseMessage resp = client.Post("https://pro.guap.ru/subjectItemStudent/").Result;
            string result = resp.Content.ReadAsStringAsync().Result;
            s_Subject answer = JsonConvert.DeserializeObject<s_SubjectAnswer>(result).Subject;
            return new Subject()
            {
                Id = answer.Id,
                Name = answer.Name,
                Department = new DictDepartment
                {
                    Id = answer.DepartmentId,
                    Name = answer.DepartmentName
                },
                ControlType = new DictControlType
                {
                    Id = answer.ControlTypeId,
                    Name = answer.ControlTypeName
                },
                Semester = new DictSemester
                {
                    Id = 0,
                    Name = answer.SemesterName
                },
                MaxPoints = answer.MaxMark,
                CurrentPoints = answer.CurrentMark,
                WorkProgrammHash = answer.Annotation.WorkProgramm.Hash,
                AnnotationHash = answer.Annotation.Annotation.Hash,
                EducationPlanHash = answer.Annotation.EducationPlan.Hash,
                Messages = answer.Messages,
                Mark = answer.Mark,
                Tasks = answer.Tasks.Select(y => new SubjectTask
                {
                    Id = y.Id,
                    Name = y.Name,
                    CurrentMark = y.CurrentMark,
                    MaxMark = y.MaxMark,
                    Status = new DictTaskStatus
                    {
                        Id = y.StatusId,
                        Name = y.StatusName
                    },
                    Group = new DictGroup
                    {
                        Id = y.GroupId,
                        Name = y.GroupName
                    },
                    IsExecuted = y.IsExecuted > 0 ? true : false
                }).ToList(),
                Materials = answer.Materials.Select(y => new SubjectMaterial
                {
                    Id = y.Id,
                    Name = y.Name,
                    Url = y.Url,
                    FileHash = y.FileLink.Substring(11),   
                }).ToList()
            };
        }

        private async Task<List<SubjectTask>> h_GetSubjectTasks(int SubjectId)
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            client.AddFormEncoded("id", SubjectId.ToString());
            client.AddFormEncoded("eid", HttpContext.User.Claims.Select(x => x.Value).ToList()[0].Substring(2));
            HttpResponseMessage resp = client.Post("https://pro.guap.ru/subjectItemStudent/").Result;
            string result = resp.Content.ReadAsStringAsync().Result;
            List<s_SubjectTask> answer = JsonConvert.DeserializeObject<s_SubjectAnswer>(result).Subject.Tasks;
            return answer.Select(y => new SubjectTask
            {
                Id = y.Id,
                Name = y.Name,
                CurrentMark = y.CurrentMark,
                MaxMark = y.MaxMark,
                Status = new DictTaskStatus
                {
                    Id = y.StatusId,
                    Name = y.StatusName
                },
                Group = new DictGroup
                {
                    Id = y.GroupId,
                    Name = y.GroupName
                },
                IsExecuted = y.IsExecuted > 0 ? true : false
            }).ToList();
        }

        private async Task<List<SubjectMaterial>> h_GetSubjectMaterials(int SubjectId)
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            client.AddFormEncoded("id", SubjectId.ToString());
            client.AddFormEncoded("eid", HttpContext.User.Claims.Select(x => x.Value).ToList()[0].Substring(2));
            HttpResponseMessage resp = client.Post("https://pro.guap.ru/subjectItemStudent/").Result;
            string result = resp.Content.ReadAsStringAsync().Result;
            List<s_SubjectMaterial> answer = JsonConvert.DeserializeObject<s_SubjectAnswer>(result).Subject.Materials;
            return answer.Select(y => new SubjectMaterial
            {
                Id = y.Id,
                Name = y.Name,
                Url = y.Url,
                FileHash = y.FileLink.Substring(11),
            }).ToList();
        }

        private async Task<byte[]> h_GetAnnotation(int SubjectId)
        {
           Subject subject = this.h_GetSubject(SubjectId).Result;
           SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
           HttpResponseMessage resp = client.Post("https://pro.guap.ru/get-student-eduplan/" + subject.AnnotationHash).Result;
           return resp.Content.ReadAsByteArrayAsync().Result;
        }

        private async Task<byte[]> h_GetWorkProgramm(int SubjectId)
        {
            Subject subject = this.h_GetSubject(SubjectId).Result;
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            HttpResponseMessage resp = client.Post("https://pro.guap.ru/get-student-eduplan/" + subject.WorkProgrammHash).Result;
            return resp.Content.ReadAsByteArrayAsync().Result;
        }

        private async Task<byte[]> h_GetEducationPlan(int SubjectId)
        {
            Subject subject = this.h_GetSubject(SubjectId).Result;
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            HttpResponseMessage resp = client.Post("https://pro.guap.ru/get-student-eduplan/" + subject.EducationPlanHash).Result;
            return resp.Content.ReadAsByteArrayAsync().Result;
        }
    }
}
