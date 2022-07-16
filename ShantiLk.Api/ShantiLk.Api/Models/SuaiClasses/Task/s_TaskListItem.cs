using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Task
{
    public class s_TaskListItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("user_id")]
        public int TeacherId { get; set; }

        [JsonProperty("datecreate")]
        public DateTime? DateCreate { get; set; }

        [JsonProperty("dateupdate")]
        public DateTime? DateUpdate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public int TaskTypeId { get; set; }

        [JsonProperty("tt_name")]
        public string TaskTypeName { get; set; }

        [JsonProperty("semester")]
        public int SemesterNumber { get; set; }

        [JsonProperty("markpoint")]
        public int? MaxMark { get; set; }

        [JsonProperty("curPoints")]
        public int? CurrentMark { get; set; }

        [JsonProperty("reportRequired")]
        public int IsReportRequired { get; set; }

        [JsonProperty("harddeadline")]
        public DateTime? DeadLine { get; set; }

        [JsonProperty("grid")]
        public int GroupId { get; set; }

        [JsonProperty("subject")]
        public int SubjectId { get; set; }

        [JsonProperty("subject_name")]
        public string SubjectName { get; set; }

        [JsonProperty("semester_name")]
        public string SemesterName { get; set; }

        [JsonProperty("status")]
        public int? StatusId { get; set; }

        [JsonProperty("status_name")]
        public string StatusName { get; set; }

    }
}
