using ShipService.Data;
using ShipService.Persistence.Settings;

namespace ShipService.Persistence;

public class ShipRepository : GenericRepository<Ship>, IShipRepository
{
    public ShipRepository(IDatabaseSettings<Ship> databaseSettings) : base(databaseSettings)
    {
    }
}