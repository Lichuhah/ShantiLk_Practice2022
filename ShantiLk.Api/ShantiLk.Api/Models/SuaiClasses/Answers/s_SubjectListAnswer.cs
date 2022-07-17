using Newtonsoft.Json;
using ShantiLk.Api.Models.SuaiClasses.Subject;

namespace ShantiLk.Api.Models.SuaiClasses.Answers
{
    public class s_SubjectListAnswer
    {
        [JsonProperty("subjects")]
        public List<s_SubjectListItem> Subjects { get; set; }

        [JsonProperty("dictionaries")]
        public s_SubjectListDictionares Dictionares { get; set; }
    }
}
