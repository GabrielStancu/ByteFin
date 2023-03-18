using DataCollectionService.Business.Models;
using DataCollectionService.Configuration;
using DataCollectionService.Data.Settings;

namespace DataCollectionService.Data;

public abstract class DatabaseSettings<T> : IDatabaseSettings<T> where T : ModelBase
{
    public string ConnectionString { get; } = string.Empty;
    public string DatabaseName { get; } = string.Empty;
    public abstract string CollectionName { get; }

    protected DatabaseSettings(IDatabaseConfiguration config)
    {
        ConnectionString = config.ConnectionString;
        DatabaseName = config.DatabaseName;
    }
}
