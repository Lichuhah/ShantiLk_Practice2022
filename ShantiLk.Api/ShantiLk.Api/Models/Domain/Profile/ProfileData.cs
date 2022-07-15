using Newtonsoft.Json;

namespace ShantiLk.Api.Models.Domain.Profile
{
    public class ProfileData
    {
        [JsonProperty("id")]
        public int Id { get; set; }
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
    }
}
