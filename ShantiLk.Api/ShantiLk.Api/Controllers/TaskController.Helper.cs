using Newtonsoft.Json;
using ShantiLk.Api.Models.ShantiClasses.Dict;
using ShantiLk.Api.Models.ShantiClasses.Task;
using ShantiLk.Api.Models.SuaiClasses.Answers;
using ShantiLk.Api.Models.SuaiClasses.Task;
using Task = ShantiLk.Api.Models.ShantiClasses.Task.Task;

namespace ShantiLk.Api.Controllers
{
    public partial class TaskController
    {
        private async Task<List<TaskListItem>> h_GetTasks()
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            client.AddFormEncoded("iduser", "0");
            HttpResponseMessage resp = client.Post("https://pro.guap.ru/get-student-tasksdictionaries/").Result;
            string result = resp.Content.ReadAsStringAsync().Result;
            List<s_TaskListItem> data = JsonConvert.DeserializeObject<s_TaskListAnswer>(result).Tasks;
            return data.Select(x => new TaskListItem()
            {
                Id = x.Id,
                Name = x.Name,
                DeadLine = x.DeadLine,
                CurrentMark = x.CurrentMark,
                MaxMark = x.MaxMark,
                Type = new DictTaskType()
                {
                    Id = x.TaskTypeId,
                    Name = x.TaskTypeName
                },
                Subject = new DictSubject()
                {
                    Id = x.SubjectId,
                    Name = x.SubjectName
                },
                Semester = new DictSemester()
                {
                    Id = x.SemesterNumber,
                    Name = x.SemesterName
                },
                Status = new Models.ShantiClasses.Dict.DictTaskStatus()
                {
                    Id = x.StatusId,
                    Name = x.StatusName
                }
            }).ToList();
        }

        private async Task<Task> h_GetTask(int id)
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            client.AddFormEncoded("task_id", id.ToString());
            HttpResponseMessage resp = client.Post("https://pro.guap.ru/get-student-task/" + id.ToString()).Result;
            string result = resp.Content.ReadAsStringAsync().Result;
            s_TaskAnswer answer = JsonConvert.DeserializeObject<s_TaskAnswer>(result);
            s_Task taskData = answer.TaskArray[0];
            return new Task()
            {
                Id = taskData.Id,
                Name = taskData.Name,
                DeadLine = taskData.DeadLine,
                MaxMark = taskData.MaxMark,
                Type = new DictTaskType()
                {
                    Id = taskData.TaskTypeId,
                    Name = taskData.TaskTypeName
                },
                Subject = new DictSubject()
                {
                    Id = taskData.SubjectId,
                    Name = taskData.SemesterName
                },
                Semester = new DictSemester()
                {
                    Id = taskData.SemesterNumber,
                    Name = taskData.SemesterName
                },
                Teacher = new DictTeacher()
                {
                    Id = taskData.TeacherId,
                    Name = taskData.TeacherName
                },
                File = new DictFile()
                {
                    Link = taskData.FileLink,
                    Name = taskData.FileName
                },
                Reports = answer.Reports.Select(x=>new Report
                {
                    Id = x.Id,
                    DateCreated = x.CreatedDate,
                    DateChecked = x.CheckedDate,
                    StudentComment = x.StudentComment,
                    TeacherComment = x.TeacherComment,
                    FileLink = x.FileLink,
                    CurrentMark = answer.Reports.LastOrDefault()?.Mark, 
                    Status = new Models.ShantiClasses.Dict.DictTaskStatus
                    {
                        Id = x.StatusId,
                        Name = x.StatusName
                    },                   
                }).ToList()
            };
        }
    }
}
