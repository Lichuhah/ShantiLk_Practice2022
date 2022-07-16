using Newtonsoft.Json;
using ShantiLk.Api.Models.SuaiClasses.Dict;

namespace ShantiLk.Api.Models.SuaiClasses.Answers
{
    public class MaterialListDictionares
    {
        [JsonProperty("subjects")]
        public List<d_Subject> Subjects;

        [JsonProperty("semester")]
        public List<d_Semester> Semesters;
    }
}
