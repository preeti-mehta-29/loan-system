using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LoanService.Models
{
    public class Loan
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DisplayName("Loan Type")]
        public string LoanType { get; set; } = string.Empty;
       // public string Status { get; set; } = string.Empty;
        [Required]
        public int LoanTerm { get; set; }
        [Required]
        [DisplayName("Loan Amount")]
        public decimal LoanAmount { get; set; }

        [DisplayName("Loan Date")]
        public DateTime AppliedOn { get; set; }
        public int UserId { get; set; }

    }
}
