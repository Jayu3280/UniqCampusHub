using System.ComponentModel.DataAnnotations;

namespace UniqCampusHub.Models
{
    public class Professor
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}