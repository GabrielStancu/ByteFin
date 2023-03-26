using ShipService.Contracts.CreateShipCompartments;

namespace ShipService.Business.ShipDataCollection;

public interface IShipCompartmentsCollector
{
    public Task<IEnumerable<ShipCompartmentsResponse>> GetCompartmentsAsync();
}