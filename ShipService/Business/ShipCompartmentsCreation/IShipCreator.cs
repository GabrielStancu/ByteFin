using ShipService.Contracts.CreateShipCompartments;

namespace ShipService.Business.ShipCompartmentsCreation;

public interface IShipCreator
{
    Task CreateShipWithCompartmentsAsync(CreateShipCompartmentsRequest createShipCompartmentsRequest);
}