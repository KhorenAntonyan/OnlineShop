using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories.Abstractions;
using OnlineShop.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.DAL.Repositories.Implementations
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(OnlineShopDbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);

        public virtual async Task<TEntity> FindByIdAsync(int id) => await _dbSet.FirstOrDefaultAsync(e => e.Id == id);

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task DeleteAsync(TEntity entity) => _dbSet.Remove(entity);

        public async Task UpdateAsync(TEntity entity) => _dbSet.Update(entity);
    }
}
