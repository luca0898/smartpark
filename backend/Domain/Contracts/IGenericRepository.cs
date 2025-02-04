using SmartPark.Domain.Entities;

namespace SmartPark.Domain.Contracts
{
    public interface IGenericRepository<TKey, TModel> where TModel : Entity<TKey>
    {
        Task<List<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(TKey id);
        Task InsertAsync(TModel entity);
        Task UpdateAsync(TKey id, TModel entity);
        Task DeleteAsync(TKey id);
    }
}
