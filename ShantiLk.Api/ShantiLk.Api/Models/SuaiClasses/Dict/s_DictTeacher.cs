using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Dict
{
    public class s_DictTeacher
    {
        [JsonProperty("tid")]
        public int Id { get; set; }

        [JsonProperty("uid")]
        public int UserId { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("FirstName")]
        public string Name { get; set; }

        [JsonProperty("MiddleName")]
        public string MiddleName { get; set; }
    }
}
