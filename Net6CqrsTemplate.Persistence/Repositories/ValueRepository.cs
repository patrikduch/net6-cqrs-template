using Net6CqrsTemplate.Application.Contracts.Persistence;
using Net6CqrsTemplate.Domain.Entities;
using Net6CqrsTemplate.Persistence.DbContexts;

namespace Net6CqrsTemplate.Persistence.Repositories
{
    public class ValueRepository : GenericRepository<ValueEntity>, IValueRepository
    {
        public ValueRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
