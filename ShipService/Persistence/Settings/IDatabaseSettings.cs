using ShipService.Data;

namespace ShipService.Persistence.Settings;

public interface IDatabaseSettings<T> where T : ModelBase
{
    public string DatabaseName { get; }
    public string ConnectionString { get; }
    public string CollectionName { get; }
}
