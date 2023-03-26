namespace ShipService.Contracts.CreateShipCompartments;

public class ShipCompartmentsResponse
{
    public string? ShipId { get; set; }
    public IEnumerable<string?>? CompartmentIds { get; set; }
}