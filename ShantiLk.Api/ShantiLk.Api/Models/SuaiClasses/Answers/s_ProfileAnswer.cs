using Newtonsoft.Json;
using ShantiLk.Api.Models.SuaiClasses.Profile;

namespace ShantiLk.Api.Models.SuaiClasses.Answers
{
    public class s_ProfileAnswer
    {
        [JsonProperty("user")]
        public s_User User { get; set; }

        [JsonProperty("studentinfo")]
        public s_StudentInfo Student { get; set; }
    }
}
