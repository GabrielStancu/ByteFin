using DataCollectionService.Data.Entities;

namespace DataCollectionService.Business.Environment;

public interface IGenerator<T> where T : ModelBase
{
    public Task<T> GenerateAsync(string shipId, string compartmentId);
}
