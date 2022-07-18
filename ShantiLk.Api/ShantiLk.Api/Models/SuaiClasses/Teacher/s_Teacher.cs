using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Teacher
{
    public class s_Teacher
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Login { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("firstname")]
        public string Name { get; set; }

        [JsonProperty("middlename")]
        public string MiddleName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("regEmail")]
        public string RegistrationEmail { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("image")]
        public string ImageLink { get; set; }

        [JsonProperty("degree_name")]
        public string Degree { get; set; }

        [JsonProperty("auditorium")]
        public string Auditorium { get; set; }

        [JsonProperty("up_contacts")]
        public DateTime UpdateContactsDate { get; set; }

        [JsonProperty("works")]
        public List<s_TeacherWork> Works { get; set; }
    }
}
