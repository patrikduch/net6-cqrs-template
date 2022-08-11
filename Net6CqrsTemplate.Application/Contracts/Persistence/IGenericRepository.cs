using System.Linq.Expressions;

namespace Net6CqrsTemplate.Application.Contracts.Persistence
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<IReadOnlyList<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);
        void Remove(TEntity entity);
        Task<bool> Exists(int id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
