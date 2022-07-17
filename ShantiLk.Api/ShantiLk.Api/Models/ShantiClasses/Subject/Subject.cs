using ShantiLk.Api.Models.ShantiClasses.Dict;

namespace ShantiLk.Api.Models.ShantiClasses.Subject
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DictDepartment Department { get; set;}
        public DictControlType ControlType { get; set; }
        public DictSemester Semester { get; set; }
        public string Mark { get; set; }
        public string CountHours { get; set; }
        public string WorkProgrammHash { get; set; }
        public string EducationPlanHash { get; set; }
        public string AnnotationHash { get; set; }
        public List<string> Messages { get; set; }
        public int MaxPoints { get; set; }
        public int CurrentPoints { get; set; }
        public List<SubjectTask> Tasks { get; set; }
        public List<SubjectMaterial> Materials { get; set; }
    }
}
