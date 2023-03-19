using ShipService.Business.Dtos.Replies;

namespace ShipService.Business.Services;

public interface IShipCompartmentsCollector
{
    public Task<IEnumerable<ShipCompartmentsDto>> GetCompartmentsAsync();
}