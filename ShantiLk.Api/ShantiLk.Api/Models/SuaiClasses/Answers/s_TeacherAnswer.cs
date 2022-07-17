using Newtonsoft.Json;
using ShantiLk.Api.Models.SuaiClasses.Teacher;

namespace ShantiLk.Api.Models.SuaiClasses.Answers
{
    public class s_TeacherAnswer
    {
        [JsonProperty("user")]
        public s_Teacher Teacher { get; set; }
        [JsonProperty("subgects")]
        public List<string> Subjects { get; set; }
    }
}
