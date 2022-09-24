using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Contexts;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories.Abstractions;

namespace OnlineShop.DAL.Repositories.Implementations
{
    public class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
    {
        private readonly DbSet<Photo> _dbSet;
        public PhotoRepository(OnlineShopDbContext context) : base(context)
        {
            _dbSet = context.Set<Photo>();
        }

        public async Task<Photo> FindAsync(string photoName) => await _dbSet.FirstOrDefaultAsync(p => p.PhotoURL == photoName);
    }
}
