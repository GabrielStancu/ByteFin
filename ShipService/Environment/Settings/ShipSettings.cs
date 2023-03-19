using ShipService.Data.Models;
using ShipService.Environment.Configuration;

namespace ShipService.Environment.Settings;

public class ShipSettings : DatabaseSettings<Ship>
{
    public override string CollectionName { get; }

    public ShipSettings(DatabaseConfiguration config) : base(config)
    {
        CollectionName = config.ShipCollectionName;
    }
}
