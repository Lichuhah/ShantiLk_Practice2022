using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Subject
{
    public class s_SubjectTask
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("markpoint")]
        public int MaxMark { get; set; }

        [JsonProperty("grid")]
        public int GroupId { get; set; }

        [JsonProperty("grnum")]
        public string GroupName { get; set; }

        [JsonProperty("executed")]
        public int IsExecuted { get; set; }

        [JsonProperty("status")]
        public int StatusId { get; set; }

        [JsonProperty("status_name")]
        public string StatusName { get; set; }

        [JsonProperty("curPoints")]
        public int CurrentMark { get; set; }
    }
}
