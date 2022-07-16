using Newtonsoft.Json;
using ShantiLk.Api.Models.SuaiClasses.Dict;

namespace ShantiLk.Api.Models.SuaiClasses.Answers
{
    public class s_SubjectListDictionares
    {
        [JsonProperty("years")]
        public List<s_DictYear> Subjects;

        [JsonProperty("semesters")]
        public List<s_DictSemester> Semesters;

        [JsonProperty("types")]
        public List<s_DictSubjectType> Types;

        [JsonProperty("controlTypes")]
        public List<s_DictControlType> ControlTypes;
    }
}
