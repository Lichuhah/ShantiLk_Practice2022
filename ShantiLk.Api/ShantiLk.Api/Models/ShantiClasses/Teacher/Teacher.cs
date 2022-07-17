namespace ShantiLk.Api.Models.ShantiClasses.Teacher
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Auditory { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<TeacherWork> Works { get; set; }
        public List<string> Disciplines { get; set; }
    }
}
