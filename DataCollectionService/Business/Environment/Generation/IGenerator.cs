using DataCollectionService.Business.Environment.Models;
using DataCollectionService.Business.Models;

namespace DataCollectionService.Business.Environment.Generation;

public interface IGenerator<T> where T : ModelBase
{
    public T Generate(MeasurementParameters parameters, string shipId, string compartmentId);
}
