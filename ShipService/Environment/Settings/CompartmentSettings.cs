using ShipService.Environment.Configuration;
using ShipService.Data.Models;

namespace ShipService.Environment.Settings;

public class CompartmentSettings : DatabaseSettings<Compartment>
{
    public override string CollectionName { get; }

    public CompartmentSettings(DatabaseConfiguration config) : base(config)
    {
        CollectionName = config.CompartmentCollectionName;
    }
}
