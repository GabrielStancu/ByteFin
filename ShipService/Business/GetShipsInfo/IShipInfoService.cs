using ShipService.Contracts.GetShipsInfo;

namespace ShipService.Business.GetShipsInfo;

public interface IShipInfoService
{
    Task<ShipsInfoResponse> GetShipsInfoAsync();
}