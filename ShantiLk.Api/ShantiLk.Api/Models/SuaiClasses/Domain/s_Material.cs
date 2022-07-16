using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Domain
{
    public class s_Material
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("datecreate")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("semester")]
        public int SemesterId { get; set; }

        [JsonProperty("isPublic")]
        public int IsPublic { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("filelink")]
        public string FileLink { get; set; }

        [JsonProperty("subject")]
        public int[] SubjectIdsArray { get; set; }

        [JsonProperty("groups")]
        public int[] GroupIdsArray { get; set; }
    }
}
