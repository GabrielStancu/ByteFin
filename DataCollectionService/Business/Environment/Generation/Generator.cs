using DataCollectionService.Business.Environment.Models;
using DataCollectionService.Business.Models;

namespace DataCollectionService.Business.Environment.Generation;

public abstract class Generator<T> : IGenerator<T> where T : ModelBase
{
    public abstract T Generate(MeasurementParameters parameters, string shipId, string compartmentId);

    protected double GenerateValue(MeasurementParameters parameters)
    {
        var random = new Random();
        return (random.NextDouble() * (parameters.MaxPossible - parameters.MinPossible)) + parameters.MinPossible;
    }

    protected string GenerateId(string prefix, string shipId, string compartmentId, DateTime timestamp)
        => $"{prefix}_{shipId}_{compartmentId}_{timestamp}";

    protected DateTime CurrentTime => DateTime.UtcNow;
}
