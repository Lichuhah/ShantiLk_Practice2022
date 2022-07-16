using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Dict
{
    public class s_DictGroup
    {
        [JsonProperty("IDEPC")]
        public int IDEPC { get; set; }

        [JsonProperty("grid")]
        public int Id { get; set; }

        [JsonProperty("grnum")]
        public string Number { get; set; }
    }
}
