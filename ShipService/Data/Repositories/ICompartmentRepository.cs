using ShipService.Data.Models;

namespace ShipService.Data.Repositories;

public interface ICompartmentRepository : IGenericRepository<Compartment>
{
    Task<IEnumerable<Compartment>> GetAllShipCompartmentsAsync(string shipId);
}