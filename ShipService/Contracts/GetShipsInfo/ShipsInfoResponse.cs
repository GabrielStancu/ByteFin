namespace ShipService.Contracts.GetShipsInfo;

public class ShipsInfoResponse
{
    public IEnumerable<ShipResponse>? Ships { get; set; }
}