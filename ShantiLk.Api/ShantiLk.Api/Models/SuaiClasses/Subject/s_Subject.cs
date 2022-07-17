using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Subject
{
    public class s_Subject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("IDEP")]
        public int IDEP { get; set; }

        [JsonProperty("chair")]
        public string DepartmentName { get; set; }

        [JsonProperty("chairId")]
        public int DepartmentId { get; set; }

        [JsonProperty("subj")]
        public string Name { get; set; }

        [JsonProperty("FYear")]
        public int FirstYear { get; set; }

        [JsonProperty("SemNum")]
        public int SemesterNumber { get; set; }

        [JsonProperty("contrText")]
        public string ControlTypeName { get; set; }

        [JsonProperty("IDContr")]
        public int ControlTypeId { get; set; }

        [JsonProperty("IsPractice")]
        public int IsPractice { get; set; }

        //[JsonProperty("TotalHours")]
        //public int CountHours { get; set; }

        [JsonProperty("WeeksInTerm")]
        public int CountWeeks { get; set; }
        [JsonProperty("realSemNum")]
        public int RealSemesterNumber { get; set; }

        [JsonProperty("rpdAnnotaion")]
        public s_SubjectAnnotation Annotation { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("semester")]
        public string SemesterName { get; set; }

        [JsonProperty("numberhours")]
        public string CountHours { get; set; }

        [JsonProperty("sumMarks")]
        public int CurrentMark { get; set; }

        [JsonProperty("summark")]
        public int MaxMark { get; set; }

        [JsonProperty("noticeMeSenpai")]
        public List<string> Messages { get; set; }

        [JsonProperty("nameMark")]
        public string Mark { get; set; }

        [JsonProperty("tasks")]
        public List<s_SubjectTask> Tasks { get; set; }

        [JsonProperty("materials")]
        public List<s_SubjectMaterial> Materials { get; set; }


    }
}
