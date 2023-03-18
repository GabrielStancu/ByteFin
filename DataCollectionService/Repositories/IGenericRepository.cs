using DataCollectionService.Data.Entities;

namespace DataCollectionService.Repositories;

public interface IGenericRepository<T> where T : ModelBase
{
    Task<T> GetAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task SaveAsync(T entity);
    Task DeleteAsync(string id);
    Task SoftDeleteAsync(string id);
    Task<T?> GetLastOccurenceAsync();
}
