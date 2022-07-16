using Newtonsoft.Json;
using ShantiLk.Api.Models.SuaiClasses.Dict;

namespace ShantiLk.Api.Models.SuaiClasses.Answers
{
    public class s_TaskListDictionares
    {
        [JsonProperty("status")]
        public List<Dict.s_DictTaskStatus> TaskStatuses;

        [JsonProperty("subject")]
        public List<s_DictSubject> Subjects;

        [JsonProperty("semester")]
        public List<s_DictSemester> Semesters;

        [JsonProperty("types")]
        public List<s_DictTaskType> TaskTypes;
    }
}
