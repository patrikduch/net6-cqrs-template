using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Net6CqrsTemplate.Domain.Entities;
using Net6CqrsTemplate.Domain.Entities.Common;

namespace Net6CqrsTemplate.Persistence.DbContexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<ValueEntity> ValueEntities { get; set; }
    }
}
