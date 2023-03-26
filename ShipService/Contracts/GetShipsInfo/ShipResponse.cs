namespace ShipService.Contracts.GetShipsInfo;

public class ShipResponse
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public DateTime BuildTime { get; set; }
    public IEnumerable<CompartmentResponse>? Compartments { get; set; }
}