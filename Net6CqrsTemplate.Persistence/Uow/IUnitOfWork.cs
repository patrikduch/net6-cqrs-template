using Microsoft.EntityFrameworkCore;

namespace Net6CqrsTemplate.Application.Contracts.Persistence.Uow;

public interface IUnitOfWork : IDisposable
{

    DbSet<T> Set<T>() where T : class;

    Task<int> Complete();
}
