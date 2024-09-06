using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace UserService.Models
{
    public class Session
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string SessionId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime ExpiredOn { get; set; }

        [Required]        
        public DateTime CreatedOn { get; set; }
    }
}
