using Loader.Core.Domain.Models;
using Loader.Core.Infrastructure.Exceptions;
using MongoDB.Driver;

namespace Loader.Core.Infrastructure.MongoDb.Repositories
{
    public class MongoDbRepositoryBase<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly MongoDbContextProvider _dbContextProvider;

        public virtual IMongoCollection<TEntity> Collection => _dbContextProvider.Collection<TEntity>();

        public MongoDbRepositoryBase(MongoDbContextProvider context)
        {
            _dbContextProvider = context;
        }

        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return (await Collection.FindAsync(Builders<TEntity>.Filter.Eq((TEntity e) => e.Id, id))).FirstOrDefault() ?? throw new EntityNotFoundException(typeof(TEntity));
        }

        public IQueryable<TEntity> ListAll()
        {
            return Collection.AsQueryable();
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await Collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await Collection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq((TEntity e) => e.Id, entity.Id), entity);
            return entity;
        }

        public async Task DeleteAsync(TPrimaryKey id)
        {
            await Collection.DeleteOneAsync(Builders<TEntity>.Filter.Eq((TEntity e) => e.Id, id));
        }
    }
}
