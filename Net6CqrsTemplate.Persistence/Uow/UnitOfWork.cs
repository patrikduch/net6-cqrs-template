using Net6CqrsTemplate.Application.Contracts.Persistence;
using Net6CqrsTemplate.Application.Contracts.Persistence.Uow;
using Net6CqrsTemplate.Persistence.DbContexts;

namespace Net6CqrsTemplate.Persistence.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public IValueRepository ValueRepository { get; set; }

        public UnitOfWork(ApplicationDbContext applicationDbContext, IValueRepository valueRepository)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
            ValueRepository = valueRepository ?? throw new ArgumentNullException(nameof(valueRepository));
        }

        public async Task<int> Complete()
        {
            return await _applicationDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }
    }
}
