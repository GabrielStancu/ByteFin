using DataCollectionService.Configuration;
using DataCollectionService.Data.Entities;

namespace DataCollectionService.Data.Settings;

public abstract class DatabaseSettings<T> : IDatabaseSettings<T> where T : ModelBase
{
    public string ConnectionString { get; } = string.Empty;
    public string DatabaseName { get; } = string.Empty;
    public abstract string CollectionName { get; }

    protected DatabaseSettings(DatabaseConfiguration config)
    {
        ConnectionString = config.ConnectionString;
        DatabaseName = config.DatabaseName;
    }
}
