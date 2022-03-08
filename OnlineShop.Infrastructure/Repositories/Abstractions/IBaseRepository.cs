using OnlineShop.DAL.Entities;
using System.Linq.Expressions;

namespace OnlineShop.DAL.Repositories.Abstractions
{
    public interface IBaseRepository<TEntity> where TEntity : IBaseEntity
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        IQueryable<TEntity> GetAll();
        void Remove(TEntity entity);
        Task<TEntity> FindByIdAsync(int id, CancellationToken cancaletionToken = default);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancaletionToken = default);
    }
}
