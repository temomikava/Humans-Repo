using HumansAPI.Data;
using HumansAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HumansAPI.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly SqlDbContext context;

        public Repository(SqlDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CheckAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().CountAsync(predicate);
        }

        public async Task<int> CreateAsync(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var item=await this.ReadAsync(id);
            context.Set<TEntity>().Remove(item);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
            return await context.SaveChangesAsync();
        }

        public async Task<TEntity?> ReadAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ReadAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(int id, TEntity entity)
        {
            var existing = context.Set<TEntity>().Find(id);

            context.Entry(existing).CurrentValues.SetValues(entity);

            return await context.SaveChangesAsync();
        }
    }
}
