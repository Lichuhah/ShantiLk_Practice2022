using Newtonsoft.Json;
using ShantiLk.Api.Models.SuaiClasses.Task;

namespace ShantiLk.Api.Models.SuaiClasses.Answers
{
    public class s_AddReportAnswer
    {
        [JsonProperty("updated")]
        public s_Report NewReport { get; set; }
    }
}
