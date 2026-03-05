using System;
using System.ComponentModel.DataAnnotations;

namespace UniqCampusHub.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string RollNumber { get; set; }

        public string Category { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }  // Only date, no time

        public string Department { get; set; }

        public string MobileNumber { get; set; }

        [EmailAddress]
        public string Gmail { get; set; }

        public string Address { get; set; }
    }
}