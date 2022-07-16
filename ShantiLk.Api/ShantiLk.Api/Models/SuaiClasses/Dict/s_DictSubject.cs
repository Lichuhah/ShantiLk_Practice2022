using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Dict
{
    public class s_DictSubject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("text")]
        public string Name { get; set; }

        [JsonProperty("semester")]
        public int? SemesterNumber { get; set; }
    }
}
