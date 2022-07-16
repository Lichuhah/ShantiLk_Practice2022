using Newtonsoft.Json;
using ShantiLk.Api.Models.SuaiClasses.Material;

namespace ShantiLk.Api.Models.SuaiClasses.Answers
{
    public class s_MaterialAnswer
    {
        [JsonProperty("dictionaries")]
        public s_MaterialListDictionares Dictionares { get; set; }

        [JsonProperty("materials")]
        public List<s_Material> Materials { get; set; }
    }
}
