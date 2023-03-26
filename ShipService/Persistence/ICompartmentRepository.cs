using ShipService.Data;

namespace ShipService.Persistence;

public interface ICompartmentRepository : IGenericRepository<Compartment>
{
    Task<IEnumerable<Compartment>> GetAllShipCompartmentsAsync(string shipId);
}