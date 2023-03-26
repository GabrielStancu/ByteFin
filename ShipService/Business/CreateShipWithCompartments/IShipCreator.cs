using ShipService.Contracts.CreateShipCompartments;

namespace ShipService.Business.CreateShipWithCompartments;

public interface IShipCreator
{
    Task CreateShipWithCompartmentsAsync(CreateShipCompartmentsRequest createShipCompartmentsRequest);
}