using Newtonsoft.Json;
using ShantiLk.Api.Models.SuaiClasses.Task;

namespace ShantiLk.Api.Models.SuaiClasses.Answers
{
    public class s_TaskAnswer
    {
        [JsonProperty("task")]
        public List<s_Task> TaskArray;

        [JsonProperty("reports")]
        public List<s_Report> Reports;
    }
}
