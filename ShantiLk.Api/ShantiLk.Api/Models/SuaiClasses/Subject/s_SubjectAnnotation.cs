using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Subject
{
    public class s_SubjectAnnotation
    {
        [JsonProperty("rpd")]
        public s_SubjectFile WorkProgramm { get; set; }

        [JsonProperty("annotation")]
        public s_SubjectFile Annotation { get; set; }

        [JsonProperty("ep")]
        public s_SubjectFile EducationPlan { get; set; }
    }
}
//https://pro.guap.ru/get-student-eduplan/910bbfc355506949ebb656ae8112fbd8