using ShantiLk.Api.Models.ShantiClasses.Dict;
using ShantiLk.Api.Models.ShantiClasses.Material;

namespace ShantiLk.Api.Models.ShantiClasses.Task
{
    public class TaskListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DeadLine { get; set; }
        public int? MaxMark { get; set; }
        public int? CurrentMark { get; set; }
        public DictSubject Subject { get; set; }
        public DictSemester Semester { get; set; }
        public Dict.DictTaskStatus Status { get; set; }
        public DictTaskType Type { get; set; }
    }
}
