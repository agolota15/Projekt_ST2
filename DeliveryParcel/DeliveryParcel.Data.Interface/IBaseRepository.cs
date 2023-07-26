using System.Linq.Expressions;

namespace DeliveryParcel.Data.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllEntitiesAsync(Expression<Func<TEntity, bool>>? filter = null, 
                                                       string? includeProperties = null);
        Task<TEntity?> GetEnttyOrDeafaultAsync(Expression<Func<TEntity, bool>> filter,
                                               bool tracked = true,
                                               string? includeProperties = null);
        Task AddEntityAsync(TEntity entity);
        Task UpdateEntityAsync(TEntity entity);
        Task DeleteEntityAsync(TEntity entity);
    }
}