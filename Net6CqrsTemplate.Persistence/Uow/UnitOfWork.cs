namespace Net6CqrsTemplate.Persistence.Uow;

using Microsoft.EntityFrameworkCore;
using Net6CqrsTemplate.Application.Contracts.Persistence;
using Net6CqrsTemplate.Application.Contracts.Persistence.Uow;
using Net6CqrsTemplate.Persistence.DbContexts;


public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UnitOfWork(ApplicationDbContext applicationDbContext, IValueRepository valueRepository)
    {
        _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
    }

    public async Task<int> Complete()
    {
        return await _applicationDbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _applicationDbContext.Dispose();
    }

    /// <summary>
    /// Dynamic load of DbSet by passed type.
    /// </summary>
    /// <typeparam name="T">Model type that will load the particular Dbset.</typeparam>
    /// <returns>Dbset of type T.</returns>
    public DbSet<T> Set<T>() where T : class
    {
        return _applicationDbContext.Set<T>();
    }
}
