using OnlineShop.DAL.Entities;

namespace OnlineShop.DAL.Repositories.Abstractions
{
    public interface IBaseRepository<TEntity> where TEntity : IBaseEntity
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task DeleteAsync(TEntity entity);
        Task<TEntity> FindByIdAsync(int id);
    }
}
