using Loader.Core.Domain.Models;

namespace Loader.Core.Domain.Repositories
{
    public interface IRepositoryBase<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        Task<TEntity> GetAsync(TPrimaryKey id);
        IQueryable<TEntity> ListAll();
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TPrimaryKey id);
    }
}
