using ShipService.Configuration;
using ShipService.Data;

namespace ShipService.Persistence.Settings;

public class ShipSettings : DatabaseSettings<Ship>
{
    public override string CollectionName { get; }

    public ShipSettings(DatabaseConfiguration config) : base(config)
    {
        CollectionName = config.ShipCollectionName;
    }
}
