using Microsoft.EntityFrameworkCore;
using TRIMANA.Customer.Domain.Entities.Client;

namespace TRIMANA.Customer.Infrastructure.Database
{
    public class CustomerDatabaseContext : DbContext
    {
        public DbSet<ClientEntity> Client { get; set; }
        public DbSet<LegalGuardianEntity> LegalGuardian { get; set; }

        public CustomerDatabaseContext(DbContextOptions<CustomerDatabaseContext> database) : base(database)
        {
        }
    }
}
