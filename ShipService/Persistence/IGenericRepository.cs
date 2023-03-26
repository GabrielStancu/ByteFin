using ShipService.Data;

namespace ShipService.Persistence;

public interface IGenericRepository<T> where T : ModelBase
{
    Task<T?> GetAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllNotDeletedAsync();
    Task SaveAsync(T entity);
    Task DeleteAsync(string id);
    Task SoftDeleteAsync(string id);
}