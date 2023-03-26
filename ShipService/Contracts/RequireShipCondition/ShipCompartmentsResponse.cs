namespace ShipService.Contracts.RequireShipCondition;

public class ShipCompartmentsResponse
{
    public string? ShipId { get; set; }
    public IEnumerable<string?>? CompartmentIds { get; set; }
}