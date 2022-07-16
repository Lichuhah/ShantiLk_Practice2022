using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Profile
{
    public class s_User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Login { get; set; }

        [JsonProperty("firstname")]
        public string Name { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("middlename")]
        public string MiddleName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("grnum")]
        public string Group { get; set; }

        [JsonProperty("vaccination")]
        public bool IsVaccination { get; set; }

        [JsonProperty("image")]
        public string ImageLink { get; set; }
    }
}
