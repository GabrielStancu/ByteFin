namespace ShipService.Business.Dtos.Replies;

public class ShipCompartmentsDto
{
    public string? ShipId { get; set; }
    public IEnumerable<string?>? CompartmentIds { get; set; }
}