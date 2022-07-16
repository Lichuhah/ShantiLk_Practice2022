using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Task
{
    public class s_Task
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("user_id")]
        public int TeacherId { get; set; }

        [JsonProperty("datecreate")]
        public DateTime? DateCreate { get; set; }

        [JsonProperty("dateupdate")]
        public DateTime? DateUpdate { get; set; }

        [JsonProperty("harddeadline")]
        public DateTime? DeadLine { get; set; }

        [JsonProperty("description")]
        public string[]? DescriptionArray { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("semester")]
        public int SemesterNumber { get; set; }

        [JsonProperty("semester_name")]
        public string SemesterName { get; set; }

        [JsonProperty("markpoint")]
        public int? MaxMark { get; set; }

        [JsonProperty("type")]
        public int TaskTypeId { get; set; }

        [JsonProperty("tt_name")]
        public string TaskTypeName { get; set; }

        [JsonProperty("filelink")]
        public string FileLink { get; set; }

        [JsonProperty("filename")]
        public string FileName { get; set; }

        [JsonProperty("subject")]
        public int SubjectId { get; set; }

        [JsonProperty("subject_name")]
        public string SubjectName { get; set; }

        [JsonProperty("groups")]
        public int[]? Groups { get; set; }

        [JsonProperty("fio")]
        public string TeacherName { get; set; }

        [JsonProperty("reportRequired")]
        public int IsReportRequired { get; set; }
    }
}
