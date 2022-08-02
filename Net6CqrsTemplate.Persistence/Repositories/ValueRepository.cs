using Net6CqrsTemplate.Application.Contracts.Persistence;
using Net6CqrsTemplate.Domain.Entities;

namespace Net6CqrsTemplate.Persistence.Repositories
{
    public class ValueRepository : GenericRepository<ValueEntity>, IValueRepository
    {
    }
}
