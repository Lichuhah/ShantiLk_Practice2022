using ShantiLk.Api.Models.ShantiClasses.Dict;

namespace ShantiLk.Api.Models.ShantiClasses.Material
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DictSubject Subject { get; set; }
        public DictSemester Semester { get; set; }
        public string FileHash { get; set; }
        public string Url { get; set; }
    }
}
