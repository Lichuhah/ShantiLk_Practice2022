using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Answers
{
    public class s_DeleteReportAnswer
    {
        [JsonProperty("result")]
        public string Success { get; set; }
        [JsonProperty("deleted")]
        public int Id { get; set; }
    }
}
