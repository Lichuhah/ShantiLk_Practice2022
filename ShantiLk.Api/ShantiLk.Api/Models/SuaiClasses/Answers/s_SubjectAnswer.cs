using Newtonsoft.Json;
using ShantiLk.Api.Models.SuaiClasses.Subject;

namespace ShantiLk.Api.Models.SuaiClasses.Answers
{
    public class s_SubjectAnswer
    {
        [JsonProperty("subject")]
        public s_Subject Subject { get; set; }
    }
}
