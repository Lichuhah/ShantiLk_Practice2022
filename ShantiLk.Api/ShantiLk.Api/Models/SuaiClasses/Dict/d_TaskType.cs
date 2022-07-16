using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Dict
{
    public class d_TaskType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
