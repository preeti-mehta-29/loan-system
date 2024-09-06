using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DisbursementService.Models
{
    public class Disbursement
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DisbursedOn { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string DisbursementStatus { get; set; } = string.Empty;
        public int LoanId { get; set; }
        public int UserId { get; set; }
    }
}
