using ShantiLk.Api.Models.ShantiClasses.Dict;

namespace ShantiLk.Api.Models.ShantiClasses.Domain
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }  
        public DateTime? CreatedDate { get; set; }
        public Subject Subject { get; set; }
        public Semester Semester { get; set; }
        public string FileLink { get; set; }
        public string Url { get; set; }
    }
}
