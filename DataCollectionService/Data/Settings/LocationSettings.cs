using DataCollectionService.Configuration;
using DataCollectionService.Data.Entities;

namespace DataCollectionService.Data.Settings;

public class LocationSettings : DatabaseSettings<Location>
{
    public override string CollectionName { get; }

    public LocationSettings(IDatabaseConfiguration config) : base(config)
    {
        CollectionName = config.LocationCollectionName;
    }
}
