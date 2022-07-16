using Newtonsoft.Json;
using ShantiLk.Api.Models.SuaiClasses.Domain;

namespace ShantiLk.Api.Models.SuaiClasses.Answers
{
    public class MaterialAnswer
    {
        [JsonProperty("dictionaries")]
        public MaterialListDictionares Dictionares { get; set; }

        [JsonProperty("materials")]
        public List<s_Material> Materials { get; set; }
    }
}
