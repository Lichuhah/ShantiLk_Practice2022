using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Dict
{
    public class d_TaskStatus
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
