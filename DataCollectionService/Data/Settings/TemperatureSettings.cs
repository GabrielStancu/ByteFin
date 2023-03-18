using DataCollectionService.Configuration;
using DataCollectionService.Data.Entities;

namespace DataCollectionService.Data.Settings;

public class TemperatureSettings : DatabaseSettings<Temperature>
{
    public override string CollectionName { get; }

    public TemperatureSettings(DatabaseConfiguration config) : base(config)
    {
        CollectionName = config.TemperatureCollectionName;
    }
}
