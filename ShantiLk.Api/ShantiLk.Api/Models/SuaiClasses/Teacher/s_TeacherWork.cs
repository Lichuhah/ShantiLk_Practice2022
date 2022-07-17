using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Teacher
{
    public class s_TeacherWork
    {
        [JsonProperty("tid")]
        public int Id { get; set; }

        [JsonProperty("post")]
        public string PostName { get; set; }

        [JsonProperty("depname")]
        public string DepartmentName { get; set; }

        [JsonProperty("faculty")]
        public string FacultyName { get; set; }

        [JsonProperty("depname_short")]
        public string DepartmentShortName { get; set; }

        [JsonProperty("faculty_short")]
        public string FacultyShortName { get; set; }

        [JsonProperty("pluralist")]
        public int IsJointWork { get; set; }
    }
}
