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
        private async Task<List<TaskListItem>> h_GetTasks(int SemesterId, int SubjectId, int TypeId, int StatusId)
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            client.AddFormEncoded("iduser", "0");
            HttpResponseMessage resp = new HttpResponseMessage();
            if (SemesterId != 0 || SubjectId != 0 || StatusId !=0 || TypeId !=0)
            {
                client.AddFormEncoded("semester", SemesterId.ToString());
                client.AddFormEncoded("subject", SubjectId.ToString());
                client.AddFormEncoded("type", TypeId.ToString());
                client.AddFormEncoded("status", StatusId.ToString());
                resp = client.Post("https://pro.guap.ru/get-student-tasks/").Result;
            } else
            {
                resp = client.Post("https://pro.guap.ru/get-student-tasksdictionaries/").Result;
            }          
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
                Status = new DictTaskStatus()
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
                    Hash = taskData.FileLink.Length > 11 ? taskData.FileLink.Substring(11) : string.Empty,
                    Name = taskData.FileName
                },
                Reports = answer.Reports.Select(x=>new Report
                {
                    Id = x.Id,
                    DateCreated = x.CreatedDate,
                    DateChecked = x.CheckedDate,
                    StudentComment = x.StudentComment,
                    TeacherComment = x.TeacherComment,
                    FileHash = x.FileLink.Substring(12),
                    CurrentMark = answer.Reports.LastOrDefault()?.Mark, 
                    Status = new DictTaskStatus
                    {
                        Id = x.StatusId,
                        Name = x.StatusName
                    },                   
                }).ToList()
            };
        }

        private async Task<byte[]> h_GetMaterialForTask(int id)
        {
            Task task = this.h_GetTask(id).Result;
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            HttpResponseMessage resp = client.Post("https://pro.guap.ru/get-task/" + task.File.Hash).Result;
            return resp.Content.ReadAsByteArrayAsync().Result;
        }

        private async Task<List<Report>> h_GetReportsForTask(int id)
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            client.AddFormEncoded("task_id", id.ToString());
            HttpResponseMessage resp = client.Post("https://pro.guap.ru/get-student-task/" + id.ToString()).Result;
            string result = resp.Content.ReadAsStringAsync().Result;
            s_TaskAnswer answer = JsonConvert.DeserializeObject<s_TaskAnswer>(result);
            return answer.Reports.Select(x => new Report
            {
                Id = x.Id,
                DateCreated = x.CreatedDate,
                DateChecked = x.CheckedDate,
                StudentComment = x.StudentComment,
                TeacherComment = x.TeacherComment,
                Status = new DictTaskStatus
                {
                    Id = x.Id,
                    Name = x.StatusName
                },
                FileHash = x.FileLink.Substring(12),
                CurrentMark = x.Mark
            }).ToList();
        }

        private async Task<byte[]> h_DownloadReport(string hash)
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            HttpResponseMessage resp = client.Get("https://pro.guap.ru/get-report/" + hash).Result;
            return resp.Content.ReadAsByteArrayAsync().Result;
        }

        private async Task<Report> h_AddReport(int taskId, NewReport report)
        {
            Task task = this.h_GetTask(taskId).Result;
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            client.AddFormData(taskId.ToString(), "task_id");
            client.AddFormData(report.Comment, "stud_comment");
            client.AddFile(report.Data, "file", report.FileName);
            client.AddFormData(task.Teacher.Id.ToString(), "prof_user");
            client.AddFormData("1", "status");
            HttpResponseMessage resp = client.PostFile("https://pro.guap.ru/reports").Result;
            string answer = resp.Content.ReadAsStringAsync().Result;
            s_Report newReport = JsonConvert.DeserializeObject<s_AddReportAnswer>(answer).NewReport;
            return new Report
            {
                Id = newReport.Id,
                StudentComment = newReport.StudentComment,
                FileHash = newReport.FileLink.Substring(12),
                Status = new DictTaskStatus
                {
                    Id = newReport.StatusId,
                    Name = newReport.StatusName
                },
                DateCreated = newReport.CreatedDate  
            };
        }

        private async Task<bool> h_DeleteReport(int reportId)
        {
            SuaiHttpClient client = new SuaiHttpClient(HttpContext.User);
            HttpResponseMessage resp = client.Delete("https://pro.guap.ru/reports/"+reportId.ToString()).Result;
            string answer = resp.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<s_DeleteReportAnswer>(answer).Success == "success" ? true : false;
        }
    }
}
