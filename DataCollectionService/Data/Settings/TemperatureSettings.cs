using DataCollectionService.Business.Models;
using DataCollectionService.Configuration;

namespace DataCollectionService.Data.Settings;

public class TemperatureSettings : DatabaseSettings<Temperature>
{
    public override string CollectionName { get; }

    public TemperatureSettings(IDatabaseConfiguration config) : base(config)
    {
        CollectionName = config.TemperatureCollectionName;
    }
}
