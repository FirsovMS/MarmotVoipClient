using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmotVoipClient.DataAccess.DTO
{
    [Table("Users")]
    public class UserDTO
    {
        public int ContactId { get; set; }

        public int SessionId { get; set; }

        public int SettingsId { get; set; }
    }
}
