using DataCollectionService.Business.Models;
using DataCollectionService.Configuration;

namespace DataCollectionService.Data.Settings;

public class HumiditySettings : DatabaseSettings<Humidity>
{
    public override string CollectionName { get; }

    public HumiditySettings(IDatabaseConfiguration config) : base(config)
    {
        CollectionName = config.HumidityCollectionName;
    }
}
