using Newtonsoft.Json;
using ShantiLk.Api.Models.SuaiClasses.Task;

namespace ShantiLk.Api.Models.SuaiClasses.Answers
{
    public class s_TaskListAnswer
    {
        [JsonProperty("tasks")]
        public List<s_TaskListItem> Tasks;

        [JsonProperty("dictionaries")]
        public s_TaskListDictionares Dictionares;
    }
}
