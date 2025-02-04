using MongoDB.Driver;
using SmartPark.Domain.Contracts;
using SmartPark.Domain.Entities;
using System.Linq;

namespace SmartPark.Repositories.Databases.MongoDb.Implementations
{
    public abstract class NonRelationalGenericRepository<TKey, TModel>
        : IGenericRepository<TKey, TModel> where TModel : Entity<TKey>
    {
        private readonly IMongoCollection<TModel> _collection;

        public NonRelationalGenericRepository(MongoDbContext context, string collectionName)
        {
            _collection = context.GetCollection<TModel>(collectionName);
        }

        public async Task DeleteAsync(TKey id)
        {
            _ = id ?? throw new ArgumentNullException(nameof(id));

            await _collection.DeleteOneAsync(record => id.Equals(record.Id));
        }

        public async Task<List<TModel>> GetAllAsync()
        {
            return await _collection.Aggregate().ToListAsync();
        }

        public async Task<TModel> GetByIdAsync(TKey id)
        {
            return await _collection.Aggregate().Where
                
                
                .FirstOrDefaultAsync(record => id.Equals(record.Id));
        }

        public async Task InsertAsync(TModel entity)
        {
            return await _collection.Find().ToListAsync();
        }

        public async Task UpdateAsync(TKey id, TModel entity)
        {
            return await _collection.Find().ToListAsync();
        }
    }
}
