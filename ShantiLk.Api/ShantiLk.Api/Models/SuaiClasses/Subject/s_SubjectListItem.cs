using Newtonsoft.Json;
using ShantiLk.Api.Models.SuaiClasses.Dict;

namespace ShantiLk.Api.Models.SuaiClasses.Subject
{
    public class s_SubjectListItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("subj")]
        public string Name { get; set; }

        [JsonProperty("contrText")]
        public string ControlTypeName { get; set; }

        [JsonProperty("contrId")]
        public int ControlTypeId { get; set; }

        [JsonProperty("FYear")]
        public int FirstYear { get; set; }

        [JsonProperty("SemNum")]
        public int SemesterNumber { get; set; }

        [JsonProperty("RealSemNum")]
        public int RealSemesterNumber { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("semester")]
        public string SemesterName { get; set; }

        [JsonProperty("teachers")]
        public List<s_DictTeacher> Teachers { get; set; }

        [JsonProperty("groups")]
        public List<s_DictGroup> Groups { get; set; }

        [JsonProperty("noticesCount")]
        public int? NewMessagesCount { get; set; }
    }
}
