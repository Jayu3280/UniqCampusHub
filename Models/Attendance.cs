namespace UniqCampusHub.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        public string StudentName { get; set; }

        public string SubjectName { get; set; }

        public DateTime AttendanceDate { get; set; }

        public bool IsPresent { get; set; }
    }
}