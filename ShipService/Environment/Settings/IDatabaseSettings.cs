using ShipService.Data.Models;

namespace ShipService.Environment.Settings;

public interface IDatabaseSettings<T> where T : ModelBase
{
    public string DatabaseName { get; }
    public string ConnectionString { get; }
    public string CollectionName { get; }
}
