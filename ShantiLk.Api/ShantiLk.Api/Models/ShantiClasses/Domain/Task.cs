using ShantiLk.Api.Models.ShantiClasses.Dict;

namespace ShantiLk.Api.Models.ShantiClasses.Domain
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DeadLine { get; set; }
        public int? MaxMark { get; set; }
        public int? CurrentMark { get; set; }
        public Subject Subject { get; set; }
        public Semester Semester { get; set; }
        public Dict.TaskStatus Status { get; set; }
        public TaskType Type { get; set; }
        public Teacher Teacher { get; set; }
        public List<Report> Reports { get; set; }
        public Dict.File File { get; set; }
    }
}
