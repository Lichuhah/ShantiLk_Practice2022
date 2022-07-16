using Newtonsoft.Json;
using ShantiLk.Api.Models.SuaiClasses.Dict;

namespace ShantiLk.Api.Models.SuaiClasses.Answers
{
    public class s_MaterialListDictionares
    {
        [JsonProperty("subjects")]
        public List<s_DictSubject> Subjects;

        [JsonProperty("semester")]
        public List<s_DictSemester> Semesters;
    }
}
