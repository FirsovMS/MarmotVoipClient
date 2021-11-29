using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarmotVoipClient.DataAccess.DTO
{
    [Table("Contacts")]
    public class ContactDTO
    {
        [Key]
        public int PhoneNumber { get; set; }
        [Required]
        [MinLength(3), MaxLength(100)]
        public string Name { get; set; }
        public bool? Blocked { get; set; }
    }
}
