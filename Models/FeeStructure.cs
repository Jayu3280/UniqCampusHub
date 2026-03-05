using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniqCampusHub.Models
{
    public class FeeStructure
    {
        [Key]
        public int Id { get; set; }

        public string StudentName { get; set; }      // Added
        public string RollNumber { get; set; }       // Added

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalFee { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CollectedFee { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal RemainingFee { get; set; }    // Will calculate automatically
    }
}