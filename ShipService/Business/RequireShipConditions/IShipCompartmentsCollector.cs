using ShipService.Contracts.RequireShipCondition;

namespace ShipService.Business.RequireShipConditions;

public interface IShipCompartmentsCollector
{
    public Task<IEnumerable<ShipCompartmentsResponse>> GetCompartmentsAsync();
}