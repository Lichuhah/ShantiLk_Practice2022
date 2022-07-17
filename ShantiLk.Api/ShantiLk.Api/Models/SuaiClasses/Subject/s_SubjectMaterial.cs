using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Subject
{
    public class s_SubjectMaterial
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("downloadlink")]
        public string FileLink { get; set; }

        [JsonProperty("grid")]
        public int GroupId { get; set; }

        [JsonProperty("grnum")]
        public string GroupName { get; set; }
    }
}
