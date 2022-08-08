using Microsoft.EntityFrameworkCore;
using Net6CqrsTemplate.Domain.Entities;

namespace Net6CqrsTemplate.Persistence.DbContexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ValueEntity> ValueEntities { get; set; }
    }
}
