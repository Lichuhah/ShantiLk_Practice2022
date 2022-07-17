using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Subject
{
    public class s_SubjectFile
    {
        [JsonProperty("epfiles_name")]
        public string Name { get; set; }

        [JsonProperty("epfiles_origname")]
        public string FileName { get; set; }

        [JsonProperty("epfiles_type")]
        public int Type { get; set; }

        [JsonProperty("epfiles_hash")]
        public string Hash { get; set; }
    }
}
