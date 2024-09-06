using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LoanApprovalService.Models
{
    public class LoanApproval
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Status { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; }
        [Required]
        public int LoanId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
