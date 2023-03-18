using DataCollectionService.Configuration;
using DataCollectionService.Data.Entities;

namespace DataCollectionService.Data.Settings;

public class HumiditySettings : DatabaseSettings<Humidity>
{
    public override string CollectionName { get; }

    public HumiditySettings(DatabaseConfiguration config) : base(config)
    {
        CollectionName = config.HumidityCollectionName;
    }
}
