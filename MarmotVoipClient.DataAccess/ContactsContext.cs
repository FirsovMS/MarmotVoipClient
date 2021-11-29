using MarmotVoipClient.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmotVoipClient.DataAccess
{
    public class ContactsContext : DbContext
    {
        public ContactsContext() : base("DefaultConnection")
        {
        }

        public DbSet<ContactDTO> Contacts { get; set; }
    }
}
