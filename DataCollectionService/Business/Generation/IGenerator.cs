using DataCollectionService.Business.Models;

namespace DataCollectionService.Business.Generation;

public interface IGenerator<T> where T : ModelBase
{
    public T Generate();
    public IEnumerable<T> BulkGenerate();
}
