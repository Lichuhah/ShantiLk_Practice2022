using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Profile
{
    public class s_ProfileEducationPlan
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("origname")]
        public string OriginalName { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }
    }
}
