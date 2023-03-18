using DataCollectionService.Configuration;
using DataCollectionService.Data.Entities;

namespace DataCollectionService.Data.Settings;

public class LocationSettings : DatabaseSettings<Location>
{
    public override string CollectionName { get; }

    public LocationSettings(DatabaseConfiguration config) : base(config)
    {
        CollectionName = config.LocationCollectionName;
    }
}
