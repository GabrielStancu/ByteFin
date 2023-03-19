using ShipService.Data.Models;
using ShipService.Environment.Configuration;

namespace ShipService.Environment.Settings;

public abstract class DatabaseSettings<T> : IDatabaseSettings<T> where T : ModelBase
{
    public string ConnectionString { get; }
    public string DatabaseName { get; }
    public abstract string CollectionName { get; }

    protected DatabaseSettings(DatabaseConfiguration config)
    {
        ConnectionString = config.ConnectionString;
        DatabaseName = config.DatabaseName;
    }
}
