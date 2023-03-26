using ShipService.Data;
using ShipService.Configuration;

namespace ShipService.Persistence.Settings;

public class CompartmentSettings : DatabaseSettings<Compartment>
{
    public override string CollectionName { get; }

    public CompartmentSettings(DatabaseConfiguration config) : base(config)
    {
        CollectionName = config.CompartmentCollectionName;
    }
}
