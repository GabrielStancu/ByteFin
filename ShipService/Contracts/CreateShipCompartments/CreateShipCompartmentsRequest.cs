namespace ShipService.Contracts.CreateShipCompartments;

public class CreateShipCompartmentsRequest
{
    public string? ShipName { get; set; }
    public DateTime? CreatedDate { get; set; }
    public IEnumerable<string?>? CompartmentNames { get; set; }
}