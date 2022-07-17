namespace ShantiLk.Api.Models.ShantiClasses.Task
{
    public class Report
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateChecked { get; set; }
        public string StudentComment { get; set; }
        public string TeacherComment { get; set; }
        public Dict.DictTaskStatus Status { get; set; }
        public string FileHash { get; set; }
        public int? CurrentMark { get; set; }
    }
}
