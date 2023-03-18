using DataCollectionService.Data.Entities;
using DataCollectionService.DTOs.Requests;

namespace DataCollectionService.Business.Environment;

public interface IGenerator<T> where T : ModelBase
{
    public T Generate(string shipId, string compartmentId);
}
