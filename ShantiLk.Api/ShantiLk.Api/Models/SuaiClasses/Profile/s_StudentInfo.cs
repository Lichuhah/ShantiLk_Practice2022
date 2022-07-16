using Newtonsoft.Json;

namespace ShantiLk.Api.Models.SuaiClasses.Profile
{
    public class s_StudentInfo
    {
        [JsonProperty("STID")]
        public int Id { get; set; }

        [JsonProperty("FirstName")]
        public string Name { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("MiddleName")]
        public string MiddleName { get; set; }

        [JsonProperty("Born")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("StudentCardNum")]
        public string StudentCardNum { get; set; }

        [JsonProperty("Chair")]
        public string DepartmentNumber { get; set; }

        [JsonProperty("depId")]
        public string InstituteId { get; set; }

        [JsonProperty("depName")]
        public string InstituteName { get; set; }

        [JsonProperty("grid")]
        public int GroupId { get; set; }

        [JsonProperty("grnum")]
        public string GroupNumber { get; set; }

        [JsonProperty("deanshort")]
        public string DeanName { get; set; }

        [JsonProperty("dep_secretary")]
        public string SecretaryName { get; set; }

        [JsonProperty("spec_id")]
        public int SpecialityId { get; set; }

        [JsonProperty("spec_name")]
        public string SpecialityName { get; set; }

        [JsonProperty("spec_code")]
        public string SpecialityCode { get; set; }

        [JsonProperty("eduform_id")]
        public string EducationFormId { get; set; }

        [JsonProperty("eduform_name")]
        public string EducationFormName { get; set; }

        [JsonProperty("edutype_id")]
        public string EducationTypeId { get; set; }

        [JsonProperty("edutype_name")]
        public string EducationTypeName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
