using MarmotVoipClient.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmotVoipClient.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }

        public DbSet<ContactDTO> Contacts { get; set; }
    }
}
