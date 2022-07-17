using ShantiLk.Api.Models.ShantiClasses.Dict;
using ShantiLk.Api.Models.SuaiClasses.Dict;

namespace ShantiLk.Api.Models.ShantiClasses.Subject
{
    public class SubjectListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DictSemester Semester { get; set; }
        public DictControlType ControlType { get; set; }
        public int? CountMessages { get; set; }
        public List<DictTeacher> Teachers { get; set; }

    }
}
