using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace basiccrud.Models
{
    public class Transaction
    {
        [Key]
        [Required(ErrorMessage ="Id Must Be Entered")]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Acc No")]
        [Required]
        public String? AccountNumber { get; set; }
        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("Will Person")]
        [Required(ErrorMessage ="Beneficary Name Must be Mentioned")]
        public String? BeneficaryName { get; set; }
        [Column(TypeName = "nvarchar(12)")]
        [DisplayName(" Bank Name")]
        [Required]
        [MaxLength(12,ErrorMessage ="Bank Name Must be of 20 Characters")]
        public String? BankName { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("Your Local Swift Code")]
        [Required]
        [MaxLength(12,ErrorMessage ="Swift Code Must be Between 20 and 15")]
        [MinLength(6,ErrorMessage ="Swift Code Must be Between 20 and 15")]
        public String? SWIFTCODE { get; set; }
        [DisplayName("Amount")]
        [Required(ErrorMessage = "Amount must be Entered")]
        public int Amount  { get; set; }
        public DateTime  Date { get; set; }
    }
}
