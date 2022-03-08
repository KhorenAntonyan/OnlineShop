using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories.Abstractions;
using System.Linq.Expressions;

namespace OnlineShop.DAL.Repositories.Implementations
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : IBaseEntity
    {
        public TEntity Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancaletionToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindByIdAsync(int id, CancellationToken cancaletionToken = default)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
