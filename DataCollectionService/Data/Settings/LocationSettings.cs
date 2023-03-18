using DataCollectionService.Business.Models;
using DataCollectionService.Configuration;

namespace DataCollectionService.Data.Settings;

public class LocationSettings : DatabaseSettings<Location>
{
    public override string CollectionName { get; }

    public LocationSettings(IDatabaseConfiguration config) : base(config)
    {
        CollectionName = config.LocationCollectionName;
    }
}
