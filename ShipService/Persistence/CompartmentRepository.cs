using MongoDB.Driver;
using ShipService.Data;
using ShipService.Persistence.Settings;

namespace ShipService.Persistence;

public class CompartmentRepository : GenericRepository<Compartment>, ICompartmentRepository
{
    public CompartmentRepository(IDatabaseSettings<Compartment> databaseSettings) : base(databaseSettings)
    {
    }

    public async Task<IEnumerable<Compartment>> GetAllShipCompartmentsAsync(string shipId)
    {
        var shipCompartments = await Collection
            .Find(c => c.ShipId == shipId)
            .ToListAsync();

        return shipCompartments;
    }
}