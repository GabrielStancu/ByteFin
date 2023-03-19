using ShipService.Business.Dtos.Requests;

namespace ShipService.Business.Services;

public interface IShipCreator
{
    Task CreateShipWithCompartmentsAsync(CreateShipDto createShipDto);
}