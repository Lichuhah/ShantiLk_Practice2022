using Newtonsoft.Json;
using ShantiLk.Api.Models.SuaiClasses.Domain;

namespace ShantiLk.Api.Models.SuaiClasses.Answers
{
    public class TaskListAnswer
    {
        [JsonProperty("tasks")]
        public List<s_TaskListItem> Tasks;

        [JsonProperty("dictionaries")]
        public TaskListDictionares Dictionares;
    }
}
