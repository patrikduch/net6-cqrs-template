using Microsoft.EntityFrameworkCore;
using Net6CqrsTemplate.Application.Contracts.Persistence;
using Net6CqrsTemplate.Persistence.DbContexts;
using System.Linq.Expressions;

namespace Net6CqrsTemplate.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(ApplicationDbContext));
        }

        public async Task<T> Add(T entity)
        {
            await _applicationDbContext.AddAsync(entity);
            return entity;
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _applicationDbContext.Set<T>().Where(predicate);
        }

        public async Task<T> Get(int id)
        {
            var entity = await _applicationDbContext.Set<T>().FindAsync(id);

            if (entity is null)
            {
                throw new NullReferenceException("No data were fetched from Entity");
            }

            return entity;
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _applicationDbContext.Set<T>().ToListAsync();
        }

        public void Remove(T entity)
        {
            _applicationDbContext.Remove(entity);
        }
    }
}
