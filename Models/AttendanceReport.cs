using System.ComponentModel.DataAnnotations;

namespace UniqCampusHub.Models
{
    public class AttendanceReport
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public string StudentName { get; set; }

        public int TotalDays { get; set; }

        public int PresentDays { get; set; }

        public int AbsentDays { get; set; }

        public double AttendancePercentage { get; set; }
    }
}