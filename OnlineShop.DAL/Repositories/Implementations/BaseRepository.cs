using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories.Abstractions;
using OnlineShop.DAL.Contexts;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OnlineShop.DAL.Repositories.Implementations
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly OnlineShopDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(OnlineShopDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.ToList().AsQueryable();
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            
            return entity;
        }
    }
}
