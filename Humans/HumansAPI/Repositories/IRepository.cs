using HumansAPI.Models.Domain;
using System.Linq.Expressions;

namespace HumansAPI.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<int> CreateAsync(TEntity entity);
        Task<TEntity?> ReadAsync(int id);
        Task<IEnumerable<TEntity>> ReadAsync();
        Task<IEnumerable<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> UpdateAsync(int id, TEntity entity);
        Task<int> DeleteAsync(int id);
        Task<int> DeleteAsync(TEntity entity);
        Task<int> DeleteRangeAsync(IEnumerable<TEntity> entities);
        Task<bool> CheckAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
