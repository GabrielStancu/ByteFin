using DataCollectionService.Data.Entities;

namespace DataCollectionService.Business.Environment;

public abstract class Generator<T> : IGenerator<T> where T : ModelBase
{
    public abstract Task<T> GenerateAsync(string shipId, string compartmentId);

    protected double GenerateValue(double? lastValue, double minPossible, double maxPossible)
    {
        return lastValue is null 
            ? GenerateFirstValue(minPossible, maxPossible) 
            : GenerateNextValue(lastValue.Value, minPossible, maxPossible);
    }

    protected string GenerateId(string prefix, string shipId, string compartmentId, DateTime timestamp)
        => $"{prefix}_{shipId}_{compartmentId}_{timestamp}";

    protected DateTime CurrentTime => DateTime.UtcNow;

    private static double GenerateFirstValue(double minPossible, double maxPossible)
    {
        var random = new Random();
        return (random.NextDouble() * (maxPossible - minPossible)) + minPossible;
    }

    private static double GenerateNextValue(double lastValue, double minPossible, double maxPossible)
    {
        var random = new Random();
        var coefficient = random.NextDouble() >= 0.5 ? 1.0 : -1.0;
        var delta = random.NextDouble();
        var value = lastValue + coefficient * delta;

        if (value < minPossible)
        {
            value = minPossible;
        }
        else if (value > maxPossible)
        {
            value = maxPossible;
        }

        return value;
    }
}
