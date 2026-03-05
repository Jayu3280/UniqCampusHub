namespace UniqCampusHub.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }

        public string? LectureTime { get; set; }      // nullable
        public string? LectureCoordinate { get; set; } // nullable
    }
}