using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarmotVoipClient.DataAccess.DTO
{
    [Table("Contacts")]
    public class ContactDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ContactId { get; set; }

        public int PhoneNumber { get; set; }

        [Required, MinLength(3), MaxLength(100)]
        public string Name { get; set; }

        public bool Blocked { get; set; }
    }
}
