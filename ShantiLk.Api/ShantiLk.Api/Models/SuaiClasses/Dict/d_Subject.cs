using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Dict
{
    public class d_Subject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("text")]
        public string Name { get; set; }

        [JsonProperty("semester")]
        public int SemesterNumber { get; set; }
    }
}
