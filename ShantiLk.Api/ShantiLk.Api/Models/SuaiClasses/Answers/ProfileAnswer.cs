using Newtonsoft.Json;
using ShantiLk.Api.Models.Domain.Profile;
using ShantiLk.Api.Models.SuaiClasses.Domain;

namespace ShantiLk.Api.Models.SuaiClasses.Answers
{
    public class ProfileAnswer
    {
        [JsonProperty("user")]
        public s_User User { get; set; }

        [JsonProperty("studentinfo")]
        public s_StudentInfo Student { get; set; }
    }
}
