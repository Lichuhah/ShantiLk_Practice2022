using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Domain
{
    public class s_Report
    {
        [JsonProperty("user_fio")]
        public string StudentName { get; set; }

        [JsonProperty("prof_fio")]
        public string TeacherName { get; set; }

        [JsonProperty("filelink")]
        public string FileLink { get; set; }

        [JsonProperty("status_name")]
        public string StatusName { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("task_id")]
        public string TaskId { get; set; }

        [JsonProperty("task_name")]
        public string TaskName { get; set; }

        [JsonProperty("task_markpoint")]
        public string IsReportRequired { get; set; }

        [JsonProperty("status")]
        public int StatusId { get; set; }

        [JsonProperty("user_id")]
        public int StudentId { get; set; }

        [JsonProperty("prof_user")]
        public int TeacherId { get; set; }

        [JsonProperty("created")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("checked")]
        public DateTime? CheckedDate { get; set; }

        [JsonProperty("stud_comment")]
        public string StudentComment { get; set; }

        [JsonProperty("prof_comment")]
        public string TeacherComment { get; set; }

        [JsonProperty("markpoint")]
        public int Mark { get; set; }

        [JsonProperty("group_id")]
        public int GroupId { get; set; }

        [JsonProperty("group_num")]
        public string GroupNumber { get; set; }
    }
}
