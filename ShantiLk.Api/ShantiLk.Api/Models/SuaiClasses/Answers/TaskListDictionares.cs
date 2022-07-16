using Newtonsoft.Json;
using ShantiLk.Api.Models.SuaiClasses.Dict;

namespace ShantiLk.Api.Models.SuaiClasses.Answers
{
    public class TaskListDictionares
    {
        [JsonProperty("status")]
        public List<Dict.d_TaskStatus> TaskStatuses;

        [JsonProperty("subject")]
        public List<d_Subject> Subjects;

        [JsonProperty("semester")]
        public List<d_Semester> Semesters;

        [JsonProperty("types")]
        public List<d_TaskType> TaskTypes;
    }
}
