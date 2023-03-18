using DataCollectionService.Data.Entities;

namespace DataCollectionService.Business.Environment;

public abstract class Generator<T> : IGenerator<T> where T : ModelBase
{
    public abstract T Generate(string shipId, string compartmentId);

    protected double GenerateValue(double minPossible, double maxPossible)
    {
        var random = new Random();
        return (random.NextDouble() * (maxPossible - minPossible)) + minPossible;
    }

    protected string GenerateId(string prefix, string shipId, string compartmentId, DateTime timestamp)
        => $"{prefix}_{shipId}_{compartmentId}_{timestamp}";

    protected DateTime CurrentTime => DateTime.UtcNow;
}
