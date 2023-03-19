using ShipService.Data.Models;

namespace ShipService.Data.Repositories;

public interface IGenericRepository<T> where T : ModelBase
{
    Task<T?> GetAsync(string id);
    Task<IEnumerable<T?>?> GetAllAsync();
    Task SaveAsync(T entity);
    Task DeleteAsync(string id);
    Task SoftDeleteAsync(string id);
}