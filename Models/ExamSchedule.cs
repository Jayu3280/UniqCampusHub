using System;
using System.ComponentModel.DataAnnotations;

namespace UniqCampusHub.Models
{
    public class ExamSchedule
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExamDate { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }
    }
}