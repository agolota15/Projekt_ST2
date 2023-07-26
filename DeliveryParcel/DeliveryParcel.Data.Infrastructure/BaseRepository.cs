using DeliveryParcel.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DeliveryParcel.Data.Infrastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();

        }
        public async Task AddEntityAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
        }
        public async Task DeleteEntityAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await SaveAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAllEntitiesAsync(Expression<Func<TEntity, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            if (includeProperties is not null)
                foreach (var includeProp in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProp);

            if (filter is not null)
                query = query.Where(filter);

            return await query.ToArrayAsync();
        }
        public async Task<TEntity?> GetEnttyOrDeafaultAsync(
            Expression<Func<TEntity, bool>> filter, bool tracked = true, string? includeProperties = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (includeProperties is not null)
                foreach (var includeProp in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProp);

            if (filter is not null)
                query = query.Where(filter);

            return await query.FirstOrDefaultAsync();
        }
        public async Task UpdateEntityAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
        }
        // Zapisuje zmiany
        private async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Wystąpił błąd.", ex);
            }
        }
    }
}
