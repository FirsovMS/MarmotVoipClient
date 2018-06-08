using MarmotVoipClient.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MarmotVoipClient.DataAccess
{
    public class MarmotVoipClientDbContext : DbContext
    {
        public MarmotVoipClientDbContext() : base("MarmotVoipClientDb")
        {
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<CallHistoryItem> CallHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
