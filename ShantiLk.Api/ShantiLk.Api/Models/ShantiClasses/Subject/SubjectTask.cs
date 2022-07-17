using ShantiLk.Api.Models.ShantiClasses.Dict;

namespace ShantiLk.Api.Models.ShantiClasses.Subject
{
    public class SubjectTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxMark { get; set; }
        public DictGroup Group { get; set; }
        public bool IsExecuted { get; set; }
        public DictTaskStatus Status { get; set; }
        public int CurrentMark { get; set; }
    }
}
